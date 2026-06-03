#Mark Molabola
import random
import sorobn as hh
import pandas as pd

#Data from Figure 1
P_C = {True: 0.5, False: 0.5}

P_S_given_C = {
    (True, True): 0.1, (True, False): 0.9,
    (False, True): 0.5, (False, False): 0.5
}

P_R_given_C = {
    (True, True): 0.8, (True, False): 0.2,
    (False, True): 0.2, (False, False): 0.8
}

P_W_given_SR = {
    (True, True, True): 0.99, (True, True, False): 0.01,
    (True, False, True): 0.95, (True, False, False): 0.05,
    (False, True, True): 0.90, (False, True, False): 0.10,
    (False, False, True): 0.05, (False, False, False): 0.95
}


# divides each value by the total so probabilities sum to 1
def normalize(d):
    total = sum(d.values())
    return {k: v / total for k, v in d.items()}


# returns P(C | R=r, S=F, W=T) by multiplying C's prior with its children's likelihoods
def p_C_given_evid(r):
    raw = {}
    for c in (True, False):
        raw[c] = P_C[c] * P_S_given_C[(c, False)] * P_R_given_C[(c, r)]
    return normalize(raw)
 
 
# returns P(R | C=c, S=F, W=T) using R's parent C and child W
def p_R_given_evid(c):
    raw = {}
    for r in (True, False):
        raw[r] = P_R_given_C[(c, r)] * P_W_given_SR[(False, r, True)]
    return normalize(raw)


# formats a probability dict as <p_true, p_false> with 4 decimal places
def fmt(d):
    return f"<{d[True]:.4f}, {d[False]:.4f}>"


# builds the bayes net and returns the exact probability for P(C|-s,w)
def get_exact():
    bn = hh.BayesNet(
        ('C', ['S', 'R']),
        ('S', 'W'),
        ('R', 'W'))
    bn.P['C'] = pd.Series({True: 0.5, False: 0.5})
    bn.P['S'] = pd.Series({
        (True, True): 0.1, (True, False): 0.9,
        (False, True): 0.5, (False, False): 0.5})
    bn.P['R'] = pd.Series({
        (True, True): 0.8, (True, False): 0.2,
        (False, True): 0.2, (False, False): 0.8})
    bn.P['W'] = pd.Series({
        (True, True, True): 0.99, (True, True, False): 0.01,
        (True, False, True): 0.95, (True, False, False): 0.05,
        (False, True, True): 0.90, (False, True, False): 0.10,
        (False, False, True): 0.05, (False, False, False): 0.95})
    bn.prepare()
    result = bn.query('C', event={'S': False, 'W': True})
    return {True: float(result[True]), False: float(result[False])}

# runs gibbs sampling for n steps and returns the estimated P(C|-s,w)
def mcmc(n):
    c = random.choice([True, False])
    r = random.choice([True, False])
    count = 0

    for _ in range(n):
        pC = p_C_given_evid(r)
        c = random.random() < pC[True]

        pR = p_R_given_evid(c)
        r = random.random() < pR[True]

        if c:
            count += 1

    return {True: count / n, False: 1 - count / n}


# states: S1=(c,r), S2=(c,-r), S3=(-c,r), S4=(-c,-r)
states = [(True, True), (True, False), (False, True), (False, False)]
state_names = ["S1", "S2", "S3", "S4"]


# computes the 4x4 transition matrix between all possible states of C and R
def transition_matrix():
    Q = {}
    for (ci, ri) in states:
        pC = p_C_given_evid(ri)
        for (cj, rj) in states:
            pR = p_R_given_evid(cj)
            Q[((ci, ri), (cj, rj))] = pC[cj] * pR[rj]
    return Q


if __name__ == "__main__":
    # Part A
    print("Part A. The sampling probabilities")
    print("P(C|-s,r) =", fmt(p_C_given_evid(True)))
    print("P(C|-s,-r) =", fmt(p_C_given_evid(False)))
    print("P(R|c,-s,w) =", fmt(p_R_given_evid(True)))
    print("P(R|-c,-s,w) =", fmt(p_R_given_evid(False)))

    # Part B
    Q = transition_matrix()
    print("\nPart B. The transition probability matrix")
    header = "    "
    for s in state_names:
        header += f"  {s:7s}"
    print(header)
    for i, si in enumerate(states):
        row = f"{state_names[i]:4s}"
        for j, sj in enumerate(states):
            row += f"{  Q[(si, sj)]:8.4f}"
        print(row)

    # Part C
    exact = get_exact()
    p_exact = exact[True]

    print("\nPart C. The probability for the query P(C|-s,w)")
    print("Exact probability:", fmt(exact))

    for exponent in (3, 4, 5, 6):
        n = 10 ** exponent
        est = mcmc(n)
        error = abs(p_exact - est[True]) / p_exact * 100
        print(f"n = 10 ^ {exponent}: {fmt(est)}, error = {error:.2f} %")
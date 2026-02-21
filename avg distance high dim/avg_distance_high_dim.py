import numpy as np
import matplotlib.pyplot as plt
from scipy.spatial.distance import pdist
import sys

print(sys.executable)

#setup
results = []
rng = np.random.default_rng(42)
dims = [1, 5, 10, 50, 100, 1000, 5000, 10000]

#loop over dimensions
for d in dims:
    N = 300
    #Array shape (N, d) 
    X = rng.random((N, d), dtype=np.float32)

    # get distance and mean...also added standard deviation and coefficient of variation to answer "Do distances concentrate (i.e., become similar to each other) in higher dimensions?"
    distances = pdist(X, metric="euclidean")

    mean_dist = distances.mean()
    std_dist = distances.std()
    coefvar_dist = std_dist / mean_dist 

    results.append((d, mean_dist, coefvar_dist))
#results
print("\nd   mean_distance     coeff_var")
for d, mean_dist, coefvar_dist in results:
    print(f"{d:<5} {mean_dist:<15.6f} {coefvar_dist:.6f}")

#plotting
dims_list = [row[0] for row in results]
means_list = [row[1] for row in results]

plt.figure(figsize=(8, 5))
plt.plot(dims_list, means_list, marker="o")
plt.xscale("log")

# plt.xticks(dims_list, dims_list)
plt.xlabel("Dimension d (log scale)")
plt.ylabel("Average pairwise distanse")
plt.title("Average Distance Between Random Points in [0,1]^d")
plt.grid(True)
plt.show()
# plt.savefig("avg distance vs dimension.png", dpi=200)
# plt.close()

"""
Comment/Discussion:
As d (dimensions) increases in the hypercube, the average pairwise distance showed a clear increasing trend.
Also, in higher dimenions, to see the concentration of distances,i added another column for coefficient of variation (std/mean)
which shows how the variation of distances decreases relative to the mean as dimension increased. 
"""

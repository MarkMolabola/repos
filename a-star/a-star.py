import math
import sys
import heapq

Earth_radius = 3958.8

# Parse data into a Dictionary
def parse_coordinates(path):
    coords = {}
    with open(path, 'r') as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            try:
                city, rest = line.split(':', 1)
                rest = rest.strip().strip('()')
                lat_str, lon_str = rest.split(',')
                coords[city.strip()] = (float(lat_str), float(lon_str))
            except Exception as e:
                raise ValueError(f"Bad coordinates line: {line}") from e
    return coords


def parse_map(path):
    graph = {}
    with open(path, 'r') as f:
        for raw in f:
            line = raw.strip()
            if not line:
                continue
            if '-' not in line:
                raise ValueError(f"Bad map line (missing '-'): {line}")
            city, rest = line.split('-', 1)
            city = city.strip()
            if city not in graph:
                graph[city] = {}
            for token in rest.split(','):
                token = token.strip()
                if not token:
                    continue
                if '(' not in token or not token.endswith(')'):
                    raise ValueError(f"Bad neighbor token: {token} in line {line}")
                nb_name, dist_str = token.split('(', 1)
                nb_name = nb_name.strip()
                dist_val = float(dist_str[:-1])  # drop trailing ')'
                graph.setdefault(city, {})[nb_name] = dist_val
                graph.setdefault(nb_name, {})[city] = dist_val
    return graph


# haversine formula for distance
def haversine_miles(a, b): # a and b are coordinate tuples
    lat1, lon1 = a
    lat2, lon2 = b
    phi1, phi2 = math.radians(lat1), math.radians(lat2)
    lam1, lam2 = math.radians(lon1), math.radians(lon2)
    dphi = phi2 - phi1
    dlam = lam2 - lam1
    sin_dphi = math.sin(dphi / 2.0)
    sin_dlam = math.sin(dlam / 2.0)
    h = sin_dphi * sin_dphi + math.cos(phi1) * math.cos(phi2) * sin_dlam * sin_dlam
    return 2.0 * Earth_radius * math.asin(min(1.0, math.sqrt(h)))


# A* Search
def a_star(graph, coords, start, goal):
    if start not in graph or goal not in graph:
        raise KeyError(f"Start or Goal not found in map")
    if start not in coords or goal not in coords:
        raise KeyError(f"Start or Goal not found in coordinates")

    open_heap = []  # (f, g, city) g = cost so far, f = g + h
    heapq.heappush(open_heap, (0.0, 0.0, start))

    origin_city = {} #for creating the best path
    best_cost = {start: 0.0}

    closed = set() #for cities we've fully explored

    while open_heap: #loop to explore all cities
        f_curr, g_curr, curr = heapq.heappop(open_heap)
        if curr in closed:#already explored
            continue
        if curr == goal: 
            path = [curr]
            while curr in origin_city: #reconstruct path 
                curr = origin_city[curr] 
                path.append(curr)
            path.reverse() 
            return path, g_curr #return path and total cost

        closed.add(curr) #

        for n, w in graph.get(curr, {}).items(): #neighbors of current city
            tentative_g = g_curr + w
            if n in best_cost and tentative_g >= best_cost[n]: #find least cost
                continue
            origin_city[n] = curr
            best_cost[n] = tentative_g
            h = haversine_miles(coords[n], coords[goal])
            f = tentative_g + h
            heapq.heappush(open_heap, (f, tentative_g, n))

    return None, math.inf

def main(argv):
    if len(argv) != 3:
        print("Type in this format: python a-star.py <FromCity> <ToCity>")
        return 2
    #parse
    start, goal = argv[1], argv[2]
    coords = parse_coordinates('coordinates.txt')
    graph = parse_map('map.txt')

    try:
        path, total = a_star(graph, coords, start, goal)
    except KeyError as e:
        print(str(e))
        return 1

    print(f"From city: {start}")
    print(f"To city: {goal}")

    if path:
        route = " - ".join(path)
        print(f"Best Route: {route}")
        print(f"Total distance: {total:.2f} mi")
        return 0
    else:
        print("No route found.")
        return 1

if __name__ == '__main__':
    sys.exit(main(sys.argv))
import matplotlib.pyplot as plt
from scipy import stats

x = [ 5, 7, 8, 9]
y = [ 99, 86, 87, 90]

m, b, r, p, std_err = stats.linregress(x, y)

def computeLine(x):
  return m * x + b

eval_y = list(map(computeLine, x))
plt.plot(x, eval_y)
plt.title(std_err)
plt.scatter(x, y)
plt.show()
print(std_err)
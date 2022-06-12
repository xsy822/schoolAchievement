import math
R1, P1, R2, P2 = map(float, input().split())
comp1 = complex(R1*math.cos(P1), R1*math.sin(P1))
comp2 = complex(R2*math.cos(P2), R2*math.sin(P2))
comp3 = comp1*comp2
print('{:.2f}'.format(comp3).replace('j', 'i'))
a, b = map(int, input().split())
t = int((b-a)/100+0.5)
print('{:02}:{:02}:{:02}'.format(t//3600, t % 3600//60, t % 60))
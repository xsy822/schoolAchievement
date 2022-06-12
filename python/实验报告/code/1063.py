n = int(input())
l = [input().split() for i in range(n)]
ll = []
for i in l:
    ll.append((int(i[0])**2+int(i[1])**2)**0.5)
print('{:.2f}'.format(max(ll)))
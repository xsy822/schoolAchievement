input()
d = {}
for i in input().split():
    d[i] = d.get(i, 0)+1
s = input().split()[1:]
for i in range(len(s)):
    print(d.get(s[i], 0), end=' 'if i < len(s)-1 else '')
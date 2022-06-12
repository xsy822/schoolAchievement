S = 'PATest'
d = {}
s = input()
total = 0
for i in s:
    if i in S:
        d[i] = d.get(i, 0)+1
        total += 1
while True:
    for i in S:
        if d[i] > 0:
            print(i, end='')
            d[i] -= 1
            total -= 1
    if total == 0:
        break
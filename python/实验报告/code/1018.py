n = int(input())
count = [0, 0, 0]
count1 = {'J': 0, 'C': 0, 'B': 0}
count2 = {'J': 0, 'C': 0, 'B': 0}
char = {'J': 0, 'C': 1, 'B': 2}
for i in range(n):
    x, y = input().split()
    if x == y:
        count[1] += 1
    elif (x == 'J' and y == 'B') or (x == 'C' and y == 'J') or (x == 'B' and y == 'C'):
        count[0] += 1
        count1[x] += 1
    else:
        count[2] += 1
        count2[y] += 1
print(" ".join(str(i) for i in count))
t = count[0]
count[0] = count[2]
count[2] = t
print(" ".join(str(i) for i in count))
print(sorted(count1.items(), key=lambda x: (-x[1], x[0]))[
      0][0], sorted(count2.items(), key=lambda x: (-x[1], x[0]))[0][0])
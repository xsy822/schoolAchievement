n = int(input())
d = {}
for i in range(n):
    s = input().split()
    if s[0] not in d:
        d[s[0]] = int(s[1])
    else:
        d[s[0]] += int(s[1])
# 按分数排序d
d = sorted(d.items(), key=lambda x: x[1], reverse=True)
print('{} {}'.format(d[0][0], d[0][1]))
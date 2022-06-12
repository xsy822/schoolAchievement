ls = list(map(int, input().split(' ')))
del ls[0]
ans = [[], [], [], [], []]
for i in ls:
    ans[i % 5].append(i)
ans[0] = list(filter(lambda x: not x % 2, ans[0]))
a = []
a.append('N' if ans[0] == [] else sum(ans[0]))
a.append('N' if ans[1] == [] else sum(ans[1][::2]) - sum(ans[1][1::2]))
a.append('N' if ans[2] == [] else len(ans[2]))
a.append('N' if ans[3] == [] else '{:.1f}'.format(sum(ans[3]) / len(ans[3])))
a.append('N' if ans[4] == [] else max(ans[4]))
print(' '.join(map(str, a)))
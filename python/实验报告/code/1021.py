n = input()
ans = {}
for i in range(len(n)):
    if n[i]not in ans:
        ans[n[i]] = 1
    else:
        ans[n[i]] += 1
ans = sorted(ans.items(), key=lambda x: x[0])
for i in ans:
    print('{}:{}'.format(i[0], i[1]))
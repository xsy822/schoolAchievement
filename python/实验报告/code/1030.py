N, p = map(int, input().split())
a = list(map(int, input().split()))
a.sort()
m = 0
for i in range(N):
    m_p = a[i]*p
    next_ = i+m
    if next_ >= N:
        break
    for j in range(next_, N):
        if a[j] <= m_p:
            m += 1
        else:
            break
print(m)
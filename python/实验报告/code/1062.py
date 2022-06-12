def fun(a: int, b: int) -> bool:
    '''判断两个数是否互质'''
    if a == b:
        return False
    if a > b:
        a, b = b, a
    for i in range(2, a):
        if a % i == 0 and b % i == 0:
            return False
    return True


a, b, K = [i for i in input().split()]
Na, Ma = a.split('/')
Nb, Mb = b.split('/')
a = int(Na)/int(Ma)
b = int(Nb)/int(Mb)
if a > b:
    a, b = b, a
K = int(K)
ans = []
for i in range(max(int(a*K)-1, 1), int(b*K)+2):
    if fun(i, K) and a < i/K < b:
        ans.append('{}/{}'.format(i, K))
print(*ans)
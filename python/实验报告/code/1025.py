addr1, n, k = input().split()
n, k = int(n), int(k)
Address = []
L, N = {}, {}
for i in range(n):
    add, da, nt = input().split()
    l_ = {add: da}  # 节点地址：数据
    n_ = {add: nt}  # 节点地址：下一个节点地址
    L.update(l_)
    N.update(n_)
Address.append(addr1)  # Address存储原本的链表地址顺序
while True:
    l = len(Address)
    t = Address[l-1]
    if t == "-1":
        break
    else:
        Address.append(N[t])  # Address存储原本的链表地址顺序
res = []
index = len(Address)-1
for i in range(0, len(Address)-1, k):
    if i+k < len(Address):
        a = Address[i:i+k]
        a = a[::-1]
        res.extend(a)
    else:
        index = i
res.extend(Address[index:])
for i in range(len(res)-1):
    print(res[i], L[res[i]], res[i+1])
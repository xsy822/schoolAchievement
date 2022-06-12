N = eval(input())
coupleLis  = list()
for i in range(N):
    a, b = input().split()
    coupleLis.append((a,b))

M = eval(input())
ls = input().split()

personSet = set(ls)    
for a,b in coupleLis:
    if a in personSet and b in personSet:
        personSet.remove(a)
        personSet.remove(b)


ls = list(personSet)
ls.sort(key=lambda x:int(x))
print(len(ls))
if len(ls)>0:
    print(" ".join(ls))
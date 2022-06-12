A,B=input(),input()
s=''
for i in A:
    if i not in s:
        s+=i
for i in B:
    if i not in s:
        s+=i
print(s)
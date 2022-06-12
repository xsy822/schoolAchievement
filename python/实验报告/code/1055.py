n,k=map(int,input().split())
ls=[]
for i in range(n):
    name,height=input().split()
    ls.append([int(height),name])
 
ls.sort(key=lambda x:(-x[0],x[1])) #对ls[0]的倒序，对ls[1]的正序
 
 
n_per_row = n//k
n_last = n-(k-1)*n_per_row
person_eachrow=[ls[:n_last]] + [ls[n_last + n_per_row*i:n_last+n_per_row*(i+1)]\
                                 for i in range(k-1)]
 
for pers in person_eachrow:
    length=len(pers)
    ret=['' for i in range(length)]
    mid=length//2
    ret[mid] = pers[0][1] #每行中间的人是最高的
    cn=1
    for j in range(1,length,2):
        if j ==length-1:
            ret[mid-cn]=pers[j][1]
        else:
            ret[mid-cn]=pers[j][1]
            ret[mid+cn]=pers[j+1][1]
            cn+=1
    print(' '.join(ret))
from fractions import Fraction
def Simplify(a):
    a=list(map(int,a))
    if len(a)==1:
        if a[0]<0:
            ans='('+str(a[0])+')'
        else:
            ans=str(a[0])
    else:
        if abs(a[0])>a[1]:
            t=abs(a[0])//a[1]
            if a[0]<0:
                t=-t
            a[0]=abs(a[0])%a[1]
            ans=str(t)+" "+"/".join(str(i) for i in a)
            if t<0:
                ans="("+ans+")"
        else:
            if a[0]<0:
                ans="("+"/".join(str(i) for i in a)+")"
            else:
                ans="/".join(str(i) for i in a)
    return ans
def Print(a,ch,b,ans):
    a = Simplify(str(a).split('/'))
    b = Simplify(str(b).split('/'))
    print("{} {} {} = {}".format(a,ch,b,ans))
a,b=input().split(' ')
a=Fraction(a)
b=Fraction(b)
ans=Simplify(str(a+b).split('/'))
Print(a,"+",b,ans)
ans=Simplify(str(a-b).split('/'))
Print(a,'-',b,ans)
ans=Simplify(str(a*b).split('/'))
Print(a,'*',b,ans)
if b==0:
    ans='Inf'
else:
    ans=Simplify(str(a/b).split('/'))
Print(a,'/',b,ans)
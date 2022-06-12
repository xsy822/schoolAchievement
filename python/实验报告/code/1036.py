n, c = input().split()
n = int(n)
l = int(n/2+0.5)
# 画宽为n,高为l的正方形,符号是c,中空
for i in range(l):
    print(c*n if i == 0 or i == l-1 else c+' '*(n-2)+c)
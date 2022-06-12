n=int(input())
for i in range(n):
    A,B,C=map(int,input().split(' '))
    print('Case #{}: {}'.format(i+1,'true' if A+B>C else 'false'))
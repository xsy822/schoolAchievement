n, c = input().split()
n = int(n)
l = 0
while True:
    l += 1
    if l**2 > (n+1)/2:
        l -= 1
        break
for i in range(l, 0, -1):
    print('{}'.format(c*(i*2-1)).rjust(i*2-1+l-i))
for i in range(2, l+1):
    print('{}'.format(c*(i*2-1)).rjust(i*2-1+l-i))
print(n-(l**2*2-1))
from decimal import Decimal
n = int(input())
lst = input().split()
num = 0
ans = Decimal(0)
for i in range(n):
    try:
        a = Decimal(lst[i])
        if (a*100) % 1 != 0 or a < -1000 or a > 1000 or lst[i][-1] == '.':
            raise Exception
        ans += a
        num += 1
    except Exception:
        print("ERROR: {} is not a legal number".format(lst[i]))
if num == 0:
    print("The average of 0 numbers is Undefined")
elif num == 1:
    print("The average of 1 number is {:.2f}".format(ans))
else:
    print("The average of {} numbers is {:.2f}".format(num, ans/num))
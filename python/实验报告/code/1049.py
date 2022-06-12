from decimal import Decimal
n = int(input())
m = [Decimal(i) for i in input().split()]
rst = Decimal(0)
for i in range(n):
    rst += m[i] * (n - i) * (i + 1)
print(rst.quantize(Decimal('0.00')))
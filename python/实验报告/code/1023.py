lst = input().split()
nums = []
for i in range(len(lst)):
    nums.extend(list(str(i)*int(lst[i])))
A = sorted(list(filter(lambda x: x != '0', nums)))
B = list(filter(lambda x: x == '0', nums))
print(A[0], *B, *A[1:], sep='')
A, DA, B, DB = input().split()
A = int('0'+''.join(list(filter(lambda x: x == str(DA), A))))
B = int('0'+''.join(list(filter(lambda x: x == str(DB), B))))
print(A+B)
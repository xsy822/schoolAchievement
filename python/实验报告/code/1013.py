import sys
x = input().split()
n = int(x[0])
m = int(x[1])


def get(num):
    if num == 2 or num == 3:
        return True
    if num % 6 != 1 and num % 6 != 5:
        return False
    tps = int(num**0.5)
    for i in range(5, tps+1, 6):
        if num % i == 0 or num % (i+2) == 0:
            return False
    return True


counter = 0
printer = 0
i = 1
while counter < m:
    i = i+1
    if get(i):
        counter = counter + 1
        if counter >= n and counter <= m:
            printer = printer + 1
            sys.stdout.write(str(i))
        else:
            continue
        if printer % 10 == 0:
            sys.stdout.write('\n')
        elif counter != m:
            sys.stdout.write(' ')
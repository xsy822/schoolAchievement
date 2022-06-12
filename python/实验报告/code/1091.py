M = int(input())
lst = input().split()
for num in lst:
    flag = True
    for n in range(10):
        l = len(num)
        if num == str((int(num)**2)*n)[-l:]:
            print(n, (int(num)**2)*n)
            flag = False
            break
    if flag:
        print('No')
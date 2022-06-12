def judge(num: int) -> bool:
    '''素数'''
    if num == 1:
        return False
    if num == 2 or num == 3:
        return True
    if num % 6 != 1 and num % 6 != 5:
        return False
    for i in range(5, int(num**0.5)+1, 6):
        if num % i == 0:
            return False
    return True


_, k = [int(x) for x in input().split()]
nums = input()
for i in range(0, len(nums)-k+1):
    if judge(int(nums[i:i+k])):
        print(nums[i:i+k])
        exit()
print('404')
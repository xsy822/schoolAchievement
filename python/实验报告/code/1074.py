def sum(jinzhi, a, b):
    '''每一位的进制是进制的每一位,超过20位默认10进制,计算a+b'''
    jinzhi, a, b = list(reversed(jinzhi)), list(reversed(a)), list(reversed(b))
    result = []
    next = 0  # 下一位的进位
    for i in range(max(len(a), len(b))):
        if i < len(a):
            ai = int(a[i])
        else:
            ai = 0
        if i < len(b):
            bi = int(b[i])
        else:
            bi = 0
        if i >= 20:
            jinzhi_i = 10
        else:
            jinzhi_i = int(jinzhi[i])
            jinzhi_i = jinzhi_i if jinzhi_i > 0 else 10
        result.append(str((ai+bi+next) % jinzhi_i))
        next = (ai+bi+next)//jinzhi_i
    result.append(str(next))
    return ''.join(result[::-1])


jinzhi, a, b = input(), input(), input()
print(int(sum(jinzhi, a, b)))
def fun(lst):
    '''去除列表lst中重复的,原顺序不改变,小写字母改大写'''
    new_lst = []
    for i in lst:
        if i.upper() not in new_lst:
            new_lst.append(i.upper())
    return new_lst


a, b = input(), input()

print(*fun(list(filter(lambda x: x not in b, a))), sep='')
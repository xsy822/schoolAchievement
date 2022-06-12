def lstSub(lst1, lst2):
    lst3 = []
    lst2 = lst2[:]
    for i in lst1:
        if i in lst2:
            lst2.remove(i)
        else:
            lst3.append(i)
    return lst3


lst = list(input())
lst1 = list(input())

a = lstSub(lst, lst1)
b = lstSub(lst1, lst)
print('{} {}'.format('Yes' if len(b) == 0 else 'No',
                     len(a)if len(b) == 0 else len(b)))
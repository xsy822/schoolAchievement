n, *lst = list(map(int, input().split()))
l = [lst[i]*10+lst[j] for i in range(len(lst)) for j in range(i+1, len(lst))]
lst.reverse()
l += [lst[i]*10+lst[j] for i in range(len(lst)) for j in range(i+1, len(lst))]
print(sum(set(l)))
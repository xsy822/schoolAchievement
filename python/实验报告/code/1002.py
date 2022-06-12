x = list(map(int, list(str(sum(map(int, list(input())))))))
ans = ['ling', 'yi', 'er', 'san', 'si', 'wu', 'liu', 'qi', 'ba', 'jiu']
print(*[ans[i] for i in x])
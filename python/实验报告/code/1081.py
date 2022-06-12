n = int(input())
for _ in range(n):
    password = input()
    if len(password) < 6:
        print('Your password is tai duan le.')
        continue
    digit = False
    alpha = False
    illegal = False
    for i in password:
        if i.isdigit():
            digit = True
        elif i.isalpha():
            alpha = True
        elif i == '.':
            pass
        else:
            illegal = True
    if illegal:
        print('Your password is tai luan le.')
    elif digit and alpha:
        print('Your password is wan mei.')
    elif alpha:
        print('Your password needs shu zi.')
    elif digit:
        print('Your password needs zi mu.')
    else:
        print('Your password is wan mei.')
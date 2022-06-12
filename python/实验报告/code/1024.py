num, e = input().split("E")
out = "" if num[0] == "+" else "-"  # 先处理数的正负
a, b = num[1:].split(".")
num_ = a + b
num_e = int(e[1:])  # 指数大小
q = len(b)  # 小数部分位数

if num_e == 0:
    out = out + num[1:]
elif e[0] == "+":
    w = num_e - q
    if w < 0:#指数大小<小数位数
        out = out + num_[:(num_e + 1)] + "." + num_[(num_e + 1):]
    else:#指数大小>=小数位数
        out = out + num_ + "0" * w
else:
    out = out + "0." + "0" * (num_e - 1) + num_

print(out)
class money:
    '''哈利波特货币'''

    def __init__(self, Amount, setByStr=1):
        if setByStr:
            self.G, self.S, self.K = map(int, Amount.split('.'))
            self.N = 0
        else:
            self.N = Amount < 0
            self.setByAmount(int(Amount))

    def getAmount(self):
        return self.G * 17*29 + self.S * 29 + self.K

    def setByAmount(self, amount):
        if self.N:
            amount = -amount
        self.G = amount // (17 * 29)
        self.S = amount % (17 * 29) // 29
        self.K = amount % 29

    def __str__(self):
        return '{}{}.{}.{}'.format('-' if self.N else '', self.G, self.S, self.K)

    def __sub__(self, m):
        return money(self.getAmount() - m.getAmount(), setByStr=0)


m1, m2 = input().split()
m1 = money(m1)
m2 = money(m2)
print(m2-m1)
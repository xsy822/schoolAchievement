import os
import random
import sqlite3
import time

import jwt
from flask_cors import *
from jwt import exceptions

# token密钥
SECRET_KEY = 'XSYCLOUD'


# 数据库
dataBase = 'xsycloud.db'


def createCode():
    '''生成邀请码'''
    s = str(random.randint(0, 1000000)).zfill(6)
    return s


# 邀请码
invitionCode = createCode()


def opDb(string):
    '''修改数据库'''
    conn = sqlite3.connect(dataBase)
    cursor = conn.cursor()
    cursor.execute(string)
    cursor.close()
    conn.commit()
    conn.close()


def getDb(string):
    '''查询数据库'''
    conn = sqlite3.connect(dataBase)
    cursor = conn.cursor()
    cursor.execute(string)
    ans = cursor.fetchall()
    cursor.close()
    conn.close()
    return ans


def createToken(username, level, day):
    '''基于jwt创建token的函数'''
    global SECRET_KEY
    headers = {
        "alg": "HS256",
        "typ": "JWT"
    }
    exp = int(time.time() + day)
    payload = {
        "username": username,
        "level": level,
        "exp": exp
    }
    token = jwt.encode(payload=payload, key=SECRET_KEY,
                       algorithm='HS256', headers=headers)
    # 返回生成的token
    return token


def validateToken(token):
    '''校验token,返回解码信息'''
    global SECRET_KEY
    code = 0
    msg = None
    try:
        msg = jwt.decode(token, SECRET_KEY, 'HS256')
    except exceptions.ExpiredSignatureError:
        code = 1
        msg = 'token已失效'
    except jwt.DecodeError:
        code = 2
        msg = 'token认证失败'
    except jwt.InvalidTokenError:
        code = 3
        msg = '非法的token'
    return [code, msg]


def fileUrl(filename):
    '''创建储存目录,返回目录和带时间戳的文件名称和当前时间戳'''
    i = filename.rfind('.')
    now = time.time()
    path = 'files/{}/{}/{}/'.format(time.localtime(now)
                                    [0], time.localtime(now)[1], time.localtime(now)[2])
    if not os.path.exists(path):
        os.makedirs(path)
    return path, filename[:i]+str(int(now))+filename[i:]


def getFileName(name):
    '''从带时间戳的文件名获取原文件名和时间戳'''
    i = name.rfind('.')
    return name[:i][:-10]+name[i:], int(name[:i][-10:])


def getDate(now):
    '''时间戳返回详细时间'''
    return time.strftime("%Y-%m-%d %H:%M:%S", time.localtime(now))


def deldir(path):
    '''递归删除空文件夹'''
    for root, dirs, files in os.walk(path, topdown=False):
        if not files and not dirs:
            os.rmdir(root)


def newFilename(filename, time):
    '''返回新的文件名'''
    i = filename.rfind('.')
    return filename[:i]+str(time)+filename[i:]

import json
from urllib import parse

import flask
from flask import request, send_file
from flask_cors import *

from utils import *

# 创建一个服务
server = flask.Flask(__name__)
CORS(server, supports_credentials=True)


@server.route('/test', methods=['get'])
def test1():
    # return send_file(url, as_attachment=True)
    return "Hello World!"


"""登录部分"""


@server.route('/signup', methods=['post'])
def signup():
    '''注册'''
    try:
        global invitionCode
        data = json.loads(request.data)
        username = data['username']
        password = data['password']
        code = data['code']
        # 验证用户名是否重复
        getUsername = getDb(
            'select username from user where username="{}"'.format(username))
        if getUsername != [] and getUsername[0][0] == username:
            return json.dumps({'code': 1, 'reason': '用户名已存在'})
        else:
            # 验证邀请码
            if code == invitionCode:
                # 写入数据库
                opDb('insert into user values("{}","{}",1)'.format(
                    username, password))
                opDb('insert into count values("{}",0,128*1024*1024,0)'.format(
                    username))
                # 刷新邀请码
                invitionCode = createCode()
                return json.dumps({'code': 0})
            else:
                return json.dumps({'code': 2, 'reason': '邀请码不正确'})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/login', methods=['post'])
def login():
    '''登录'''
    try:
        data = json.loads(request.data)
        username = data['username']
        password = data['password']
        jizhu = data['jizhu']
        getUser = getDb(
            'select * from user where username="{}"'.format(username))
        if getUser == []:
            return json.dumps({'code': 1, 'reason': "用户名不正确"})
        elif getUser[0][1] != password:
            return json.dumps({'code': 2, 'reason': "密码不正确"})
        if jizhu:
            token = createToken(username, getUser[0][2], 3600*24*30)
        else:
            token = createToken(username, getUser[0][2], 3600*24)
        return json.dumps({'code': 0, 'token': token, 'level': getUser[0][2]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/validate', methods=['post'])
def validate():
    try:
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        if ans[0] == 0:
            return json.dumps({'code': 0, 'username': ans[1]['username'], 'level': ans[1]['level']})
        else:
            return json.dumps({'code': ans[0], 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


"""管理部分"""


@server.route('/invition', methods=['post'])
def getCode():
    try:
        global invitionCode
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        if ans[1]['level'] == 2:
            if ans[0] == 0:
                return json.dumps({'code': 0, 'invitionCode': invitionCode})
            else:
                return json.dumps({'code': 1, 'reason': ans[1]})
        else:
            return json.dumps({'code': 2, 'reason': '权限不足'})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/manage', methods=['get'])
def getUsers():
    try:
        page = int(request.args.get('page'))-1
        limit = int(request.args.get('limit'))
        token = request.args.get('token')
        ans = validateToken(token)
        if ans[0] == 0:
            if ans[1]['level'] == 2:
                n = ['username', 'password', 'level', 'used', 'rest', 'amount']
                s = list(map(lambda i: dict(zip(n, i)),
                             getDb('select user.username,password,level,used,rest,amount from user,count where user.username=count.username')))
                return json.dumps({'code': 0, 'msg': 'success', 'count': len(s), 'data': s[page*limit:(page+1)*limit if (page+1)*limit <= len(s) else len(s)]})
            else:
                return json.dumps({'code': 2, 'reason': '权限不足'})
        else:
            return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/deluser', methods=['post'])
def delUser():
    try:
        username = json.loads(request.data)['username']
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        if ans[1]['level'] == 2:
            if ans[0] == 0:
                if getDb('select username from user where username="{}"'.format(username)) == []:
                    return json.dumps({'code': 3, 'reason': '用户名不存在'})
                opDb('delete from user where username="{}"'.format(username))
                opDb('delete from count where username="{}"'.format(username))
                return json.dumps({'code': 0, 'msg': 'success'})
            else:
                return json.dumps({'code': 1, 'reason': ans[1]})
        else:
            return json.dumps({'code': 2, 'reason': '权限不足'})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


"""用户部分"""


@server.route('/upload', methods=['post'])
def upload():
    try:
        token = request.form.to_dict()['token']
        ans = validateToken(token)
        if ans[0] == 0:
            # 储存文件
            length = request.form.to_dict()['length']
            if int(getDb('select rest from count where username="{}"'.format(ans[1]['username']))[0][0]) < int(length):
                return json.dumps({'code': 2, 'reason': '剩余空间不足'})
            f = request.files.get('file')
            suffix = f.filename[f.filename.rfind('.')+1:]
            path, name = fileUrl(f.filename)
            f.save(path+name)
            # 修改数据库
            opDb('insert into files values("{}","{}","{}",{},"{}")'.format(
                ans[1]['username'], name, suffix, length, path+name))
            opDb('update count set used=used+{},rest=rest-{},amount=amount+1 where username="{}"'.format(
                length, length, ans[1]['username']))
            return json.dumps({'code': 0, 'msg': 'success', "data": {"src": path+name}})
        else:
            return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/count', methods=['post'])
def count():
    try:
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        if ans[0] == 0:
            getCount = getDb('select used,rest,amount from count where username="{}"'.format(
                ans[1]['username']))
            n = ['used', 'rest', 'amount']
            s = list(map(lambda i: dict(zip(n, i)), getCount))
            return json.dumps({'code': 0, 'count': s[0]})
        else:
            return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


def funOfMyFiles(x):
    '''简单处理数据'''
    x = list(x)
    x[3:3] = [x[0]]
    x[0], date = getFileName(x[0])
    x[3:3] = [getDate(date)]
    return x


@server.route('/myfiles', methods=['get'])
def myfiles():
    try:
        page = int(request.args.get('page'))-1
        limit = int(request.args.get('limit'))
        token = request.args.get('token')
        ans = validateToken(token)
        if ans[0] == 0:
            n = ['filename', 'class', 'size', 'date', 'filename1', 'url']
            s = getDb('select filename,class,size,url from files where username="{}"'.format(
                ans[1]['username']))
            s = map(funOfMyFiles, s)
            s = list(map(lambda i: dict(zip(n, i)), s))
            return json.dumps({'code': 0, 'msg': 'success', 'count': len(s), 'data': s[page*limit:(page+1)*limit if (page+1)*limit <= len(s) else len(s)]})
        else:
            return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/view', methods=['get'])
def viewfiles():
    '''预览文件'''
    try:
        token = request.args.get('token')
        ans = validateToken(token)
        filename = parse.unquote(request.args.get('filename'))
        url = parse.unquote(request.args.get('url'))
        if ans[0] == 0:
            f = getDb('select * from files where filename="{}"'.format(filename))
            if f == [] or f[0][0] != ans[1]['username']:
                return json.dumps({'code': 2, 'reason': '未拥有文件'})
            name, i = getFileName(filename)
            return send_file(url, download_name=name)
        return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/download', methods=['get'])
def downloadfiles():
    '''下载文件'''
    try:
        token = request.args.get('token')
        ans = validateToken(token)
        filename = parse.unquote(request.args.get('filename'))
        url = parse.unquote(request.args.get('url'))
        if ans[0] == 0:
            f = getDb('select * from files where filename="{}"'.format(filename))
            if f[0][0] != ans[1]['username']:
                return json.dumps({'code': 2, 'reason': '未拥有文件'})
            name, i = getFileName(filename)
            return send_file(url, as_attachment=True, download_name=name)
        return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/delfiles', methods=['post'])
def delfiles():
    try:
        filename = json.loads(request.data)['filename']
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        if ans[0] == 0:
            f = getDb(
                'select * from files where filename="{}"'.format(filename))
            if f == [] or f[0][0] != ans[1]['username']:
                return json.dumps({'code': 2, 'reason': '文件不存在'})
            opDb('delete from files where filename="{}"'.format(filename))
            opDb('update count set used=used-{},rest=rest+{},amount=amount-1 where username="{}"'.format(
                f[0][3], f[0][3], ans[1]['username']))
            os.remove(f[0][4])
            deldir('files')
            return json.dumps({'code': 0, 'msg': 'success'})
        else:
            return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/changefile', methods=['post'])
def changefile():
    try:
        filename = json.loads(request.data)['filename']
        newname = json.loads(request.data)['newname']
        newname = newFilename(newname, getFileName(filename)[1])
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        if ans[0] == 0:
            f = getDb(
                'select * from files where filename="{}"'.format(filename))
            if f == [] or f[0][0] != ans[1]['username']:
                return json.dumps({'code': 2, 'reason': '文件不存在'})
            opDb('update files set filename="{}" where filename="{}"'.format(
                newname, filename))
            return json.dumps({'code': 0, 'msg': 'success'})
        else:
            return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


@server.route('/changepwd', methods=['post'])
def changepwd():
    '''修改密码'''
    try:
        token = json.loads(request.data)['token']
        ans = validateToken(token)
        password = json.loads(request.data)['password']
        if ans[0] == 0:
            opDb('update user set password="{}" where username="{}"'.format(
                password, ans[1]['username']))
            return json.dumps({'code': 0, 'msg': 'suuccess'})
        return json.dumps({'code': 1, 'reason': ans[1]})
    except Exception as e:
        return json.dumps({'code': -1, 'reason': e.__repr__().replace("\"", " ")})


if __name__ == '__main__':
    server.run(debug=False, port=8081, host='0.0.0.0')

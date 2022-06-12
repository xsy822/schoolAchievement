# coding=utf-8
import os
from tornado.wsgi import WSGIContainer
from tornado.httpserver import HTTPServer
from tornado.ioloop import IOLoop
from xsycloud import server

if __name__ == '__main__':
    http_server = HTTPServer(WSGIContainer(server), ssl_options={
        "certfile": os.path.join(os.path.abspath("."), "证书地址"),
        "keyfile": os.path.join(os.path.abspath("."), "证书key地址"),
    })
    http_server.listen(8081)
    IOLoop.instance().start()

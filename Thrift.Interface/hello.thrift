namespace * Thrift.Service

include "model.thrift"

service helloService{

	model.helloMessageResult getMessage(1: model.helloMessage message)
}
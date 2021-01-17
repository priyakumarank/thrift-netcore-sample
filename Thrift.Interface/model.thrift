namespace * Thrift.Service.Models

include "enums.thrift"

typedef string Guid
typedef string DateTime

struct helloMessage
{
	1: Guid Id
	2: enums.MessageType Type

}

struct helloMessageResult{
	1: string Message
	2: DateTime Received
}
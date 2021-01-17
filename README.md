# thrift-netcore-sample

## Steps
1. Add Nuget Package Reference ApacheThrift version 0.13.0.1 
2. Add .thrift file
3. Download thrift.exe https://thrift.apache.org/download 
4. Add pre-build event thrift -r -gen netstd ".\hello.thrift"
5. Ensure netstd files are generated under directory "gen-netstd".

## Projects:
1. Thrift.Interface : Define thrift services and models
2. Thrift.Service: Interfaces are implemented in the service and it uses http transport 
3. Thrift.Client: Client talking to Service over http


## Reference 
 - https://thrift.apache.org/lib/netstd
 - https://github.com/apache/thrift/blob/master/tutorial/netstd/README.md

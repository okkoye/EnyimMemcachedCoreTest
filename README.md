
* `2.1.13`与`2.1.10`版本的`EnyimMemcachedCore` 同步方法(`Get`)读取缓存都是稳定的
* `2.1.13`与`2.1.10`版本的`EnyimMemcachedCore` 异步读取方法(`GetAsync`)并发数往上涨后，开始极度不稳定。相对来说`2.1.10`版本要比`2.1.13`版本要稳定一些。

* 测试一
```
siege -c 1000 -t 60s http://localhost:5000/api/values
siege -c 1000 -t 60s http://localhost:5000/api/values/async
```

* 2.1.13版本 异步方法测试结果 
```
Transactions:		          12 hits
Availability:		        0.93 %
Elapsed time:		       10.99 secs
Data transferred:	        0.04 MB
Response time:		      204.31 secs
Transaction rate:	        1.09 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		      223.09
Successful transactions:          12
Failed transactions:	        1278
Longest transaction:	       10.37
Shortest transaction:	        0.07
```
* 2.1.10版本 异步方法测试结果

Transactions:		         490 hits
Availability:		       29.22 %
Elapsed time:		       11.03 secs
Data transferred:	        0.04 MB
Response time:		        5.56 secs
Transaction rate:	       44.42 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		      246.82
Successful transactions:         490
Failed transactions:	        1187
Longest transaction:	        4.18
Shortest transaction:	        0.07

* 2.1.13版本 同步方法测试结果
```
Transactions:		       32562 hits
Availability:		       98.08 %
Elapsed time:		       59.98 secs
Data transferred:	        0.00 MB
Response time:		        0.37 secs
Transaction rate:	      542.88 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		      198.24
Successful transactions:       32562
Failed transactions:	         639
Longest transaction:	       20.86
Shortest transaction:	        0.00
```
* 2.1.10版本 同步方法测试结果
```
Transactions:		       32602 hits
Availability:		       97.70 %
Elapsed time:		       59.18 secs
Data transferred:	        0.00 MB
Response time:		        0.19 secs
Transaction rate:	      550.90 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		      106.82
Successful transactions:       32602
Failed transactions:	         767
Longest transaction:	        1.00
Shortest transaction:	        0.00
```
* 测试二
```
siege -c 100 -t 60s http://localhost:5000/api/values
siege -c 100 -t 60s http://localhost:5000/api/values/async
```

* 2.1.13版本 异步方法测试结果
```
Transactions:		        1614 hits
Availability:		       60.43 %
Elapsed time:		       11.62 secs
Data transferred:	        0.04 MB
Response time:		        0.71 secs
Transaction rate:	      138.90 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		       98.90
Successful transactions:        1614
Failed transactions:	        1057
Longest transaction:	        1.79
Shortest transaction:	        0.00
```

* 2.1.10版本 异步方法测试结果

```
Transactions:		        1120 hits
Availability:		       51.83 %
Elapsed time:		       11.76 secs
Data transferred:	        0.03 MB
Response time:		        1.04 secs
Transaction rate:	       95.24 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		       99.35
Successful transactions:        1120
Failed transactions:	        1041
Longest transaction:	        1.05
Shortest transaction:	        0.00
```

* 2.1.13版本 同步方法测试结果
```
Transactions:		       32755 hits
Availability:		       99.82 %
Elapsed time:		       59.01 secs
Data transferred:	        0.00 MB
Response time:		        0.15 secs
Transaction rate:	      555.08 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		       83.84
Successful transactions:       32755
Failed transactions:	          59
Longest transaction:	       19.75
Shortest transaction:	        0.00
```

* 2.1.10版本 同步方法测试结果

```
Transactions:		       32772 hits
Availability:		       99.70 %
Elapsed time:		       59.04 secs
Data transferred:	        0.00 MB
Response time:		        0.08 secs
Transaction rate:	      555.08 trans/sec
Throughput:		        0.00 MB/sec
Concurrency:		       43.95
Successful transactions:       32772
Failed transactions:	         100
Longest transaction:	        0.41
Shortest transaction:	        0.00
```

# 快速开始

apollo 服务搭建详见 [Apollo 快速部署](https://ctripcorp.github.io/apollo/#/zh/deployment/quick-start)

## 引入包

```
Install-Package ApolloCore -Version 0.0.1
```

## 启动

```c#
// Program.cs
public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureApolloConfiguration()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
```

```c#
// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
	...
	services.AddApolloClient(Configuration);
	...
}
```

## 增加 AppSettings.json 节点

```
"apollo": {
    "AppId": "msdemo-client",
    //"Cluster": "node1",
    "MetaServer": "http://192.168.3.67:8080/",
    "Namespaces": [ "msdemonamespace.json", "application" ],
    "ConfigServer": [ "http://192.168.3.67:8080/" ]
}
```

## 使用

```c#
[ApiController]
[Route("apollo")]
public class LoadApolloConfigureController : Controller
{
    private readonly IApolloClient _apolloClient;
    public LoadApolloConfigureController(IApolloClient apolloClient)
    {
        _apolloClient = apolloClient;
    }

    [HttpGet("{key}")]
    public async Task<string> GetAsync(string key)
    {
        var obj = await _apolloClient.GetAsync<ModConfig>(key);
        return await Task.FromResult(JsonSerializer.Serialize(obj));
    }
}
```

# 配置监控功能

如果想要开启配置文件监听功能，即 apollo 发生配置更改，客户端能触发回调事件。需要做以下配置

```c#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	...
	// 开启监听
	app.StartConfigChangeListening();
	...
}
```

除此之外还要添加监听的节点类型：

```
public void ConfigureServices(IServiceCollection services)
{
	services.AddApolloClient(Configuration)
		.AddMonitor<ModConfig>("ModConfig");
}
```

这样就能通过手动注入 IOptionMonitor<TConfig> 来实现对文件的监听了。

该组件内置了统一调度监听功能，需要添加对应的 `IConfigWatcher` 的实现即可：

```c#
public class ModConfigWatcher : ConfigWatcherBase<ModConfig>, IConfigWatcher
{
    public ModConfigWatcher(IOptionsMonitor<ModConfig> monitor) : base(monitor)
    {
    }

    protected override void RaiseChange(ModConfig config, string arg)
    {
        if (_monitor.CurrentValue.AppId != config.AppId
            || _monitor.CurrentValue.Platform != config.Platform
            || _monitor.CurrentValue.RequestId != config.RequestId
            || _monitor.CurrentValue.Userflag != config.Userflag)
            Console.WriteLine($"配置发生变动 新值为：{JsonSerializer.Serialize(config)}");
    }
}
// 注入
services.AddTransient<IConfigWatcher, ModConfigWatcher>();
```

后续会自动注入...
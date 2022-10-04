using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptionsPattern;

IServiceCollection serviceCollection = new ServiceCollection();
Register.ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

Console.WriteLine("顯示原始設定檔");
Show(serviceProvider);
Console.WriteLine("===============================");
Console.WriteLine("程式碼修改值");
Change(serviceProvider);
Show(serviceProvider);
Console.WriteLine("===============================");
Console.WriteLine("請手動修改bin\\Debug\\net6.0\\appsettings.json(修改後按enter察看結果)");
Console.ReadLine();
Show(serviceProvider);
Console.ReadLine();

static void Show(IServiceProvider serviceProvider) 
{
    using IServiceScope scope = serviceProvider.CreateScope();
    var sp = scope.ServiceProvider;
    var options = sp.GetRequiredService<IOptions<ApiGatewayOption>>().Value;
    var optionsMonitor = sp.GetRequiredService<IOptionsMonitor<ApiGatewayOption>>().CurrentValue;
    var optionsSnapshot = sp.GetRequiredService<IOptionsSnapshot<ApiGatewayOption>>().Value;

    Console.WriteLine(options.order.Get);
    Console.WriteLine(optionsMonitor.order.Get);
    Console.WriteLine(optionsSnapshot.order.Get);
}

static void Change(IServiceProvider serviceProvider)
{
    using IServiceScope scope = serviceProvider.CreateScope();
    var sp = scope.ServiceProvider;
    sp.GetRequiredService<IOptions<ApiGatewayOption>>().Value.order.Get = "api/getOrder";
    sp.GetRequiredService<IOptionsMonitor<ApiGatewayOption>>().CurrentValue.order.Get = "api/getOrder";
    sp.GetRequiredService<IOptionsSnapshot<ApiGatewayOption>>().Value.order.Get = "api/getOrder";
}

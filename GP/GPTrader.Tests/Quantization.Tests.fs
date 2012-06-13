module GPTrader.Tests

open Xunit
open GPTrader.Quantization

[<Measure>]
type RSI

[<Fact>]
let ``successful quantizer construction``() =
    let acp = Quantizer<RSI>(0.0<RSI>, 1.0<RSI>, 4)
    Assert.NotNull(acp)

[<Fact>]
let ``failed quantizer construction due to nonsense nSteps``() =
    Assert.Throws<System.ArgumentException>(fun () -> Quantizer<RSI>(0.0<RSI>, 1.0<RSI>, 1) |> ignore)

[<Fact>]
let ``failed quantizer construction due to nSteps is not power of 2``() =
    Assert.Throws<System.ArgumentException>(fun () -> Quantizer<RSI>(0.0<RSI>, 1.0<RSI>, 5) |> ignore)

[<Fact>]
let ``failed quantizer construction due to nonsense boundaries``() =
    Assert.Throws<System.ArgumentException>(fun () -> Quantizer<RSI>(1.0<RSI>, 0.0<RSI>, 4) |> ignore)

[<Fact>]
let ``correct discretization for non-negative range``() =
    let acp = Quantizer<RSI>(0.0<RSI>, 1.0<RSI>, 4)
    Assert.Equal(0<RSI>, acp.Discretize 0.0<RSI>)
    Assert.Equal(1<RSI>, acp.Discretize 0.25<RSI>)
    Assert.Equal(2<RSI>, acp.Discretize 0.5<RSI>)
    Assert.Equal(3<RSI>, acp.Discretize 0.75<RSI>)
    Assert.Equal(3<RSI>, acp.Discretize 1.0<RSI>)

[<Fact>]
let ``correct discretization for normalized range``() =
    let acp = Quantizer<RSI>(-1.0<RSI>, 1.0<RSI>, 4)
    Assert.Equal(0<RSI>, acp.Discretize -1.0<RSI>)
    Assert.Equal(1<RSI>, acp.Discretize -0.5<RSI>)
    Assert.Equal(2<RSI>, acp.Discretize 0.0<RSI>)
    Assert.Equal(3<RSI>, acp.Discretize 0.5<RSI>)
    Assert.Equal(3<RSI>, acp.Discretize 1.0<RSI>)

[<Fact>]
let ``failed discretization for nonsense argument``() =
    let acp = Quantizer<RSI>(0.0<RSI>, 1.0<RSI>, 4)
    Assert.Throws<System.ArgumentOutOfRangeException>(fun () -> acp.Discretize -1.0<RSI> |> ignore)
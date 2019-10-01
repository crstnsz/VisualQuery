using Error;

enum Operation
{
    LeftOuterJoin,
    Equal,
    Less,
    LessEqual,
    Greater,
    GreaterEqual,
    Diferente,
    Like,
    Is,
    IsNot,
    In,
    NotIn,
    Exists,
    NotExists,
    Between,
    FreeStyle
}

internal class OperationFX
{
    internal static string OperationToString(Operation operation)
    {
        switch (operation)
        {
            case Operation.Equal:
                return "=";
            case Operation.Less:
                return "<";
            case Operation.LessEqual:
                return "<=";
            case Operation.Greater:
                return ">";
            case Operation.GreaterEqual:
                return ">=";
            case Operation.Diferente:
                return "<>";
            case Operation.LeftOuterJoin:
                return "=";
            case Operation.Like:
                return "LIKE";
            case Operation.Is:
                return "IS";
            case Operation.IsNot:
                return "IS NOT";
            case Operation.In:
                return "IN";
            case Operation.NotIn:
                return "NOT IN";
            case Operation.Exists:
                return "EXISTS";
            case Operation.NotExists:
                return "NOT EXISTS";
            case Operation.Between:
                return "BETWEEN";
            case Operation.FreeStyle:
                return string.Empty;
            default:
                throw new Excessao(194);
        }
    }

    internal static Operation StringToOperation(string operation)
    {
        switch (operation.ToUpper())
        {
            case "=":
                return Operation.Equal;
            case "<":
                return Operation.Less;
            case "<=":
                return Operation.LessEqual;
            case ">":
                return Operation.Greater;
            case ">=":
                return Operation.GreaterEqual;
            case "<>":
                return Operation.Diferente;
            case "OJ":
                return Operation.LeftOuterJoin;
            case "LIKE":
                return Operation.Like;
            case "IS":
                return Operation.Is;
            case "IS NOT":
                return Operation.IsNot;
            case "IN":
                return Operation.In;
            case "NOT IN":
                return Operation.NotIn;
            case "EXISTS":
                return Operation.Exists;
            case "NOT EXISTS":
                return Operation.NotExists;
            case "BETWEEN":
                return Operation.Between;
            default:
                throw new Excessao(194);
        }
    }
}
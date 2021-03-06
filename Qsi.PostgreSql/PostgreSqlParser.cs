﻿using System;
using System.Threading;
using Qsi.Data;
using Qsi.Parsing;
using Qsi.PostgreSql.Internal;
using Qsi.PostgreSql.Internal.PG10;
using Qsi.PostgreSql.Internal.PG10.Types;
using Qsi.PostgreSql.Tree.PG10;
using Qsi.Tree;

namespace Qsi.PostgreSql
{
    public sealed class PostgreSqlParser : IQsiTreeParser, IDisposable
    {
        private IPgParser _pgParser;

        public IQsiTreeNode Parse(QsiScript script, CancellationToken cancellationToken = default)
        {
            _pgParser ??= new PgQuery10();

            var pgTree = (IPg10Node)_pgParser.Parse(script.Script) ?? throw new QsiException(QsiError.NotSupportedScript, script.ScriptType);

            switch (script.ScriptType)
            {
                case QsiScriptType.Set:
                    return ActionVisitor.Visit(pgTree);

                default:
                    return TableVisitor.Visit(pgTree);
            }
        }

        void IDisposable.Dispose()
        {
            _pgParser?.Dispose();
        }
    }
}

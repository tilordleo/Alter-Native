﻿using System;
using ICSharpCode.NRefactory.Cpp.Ast;

namespace ICSharpCode.NRefactory.Cpp.Ast
{
    /// <summary>
    /// Type&lt;[EMPTY]&gt;
    /// </summary>
    public class InterfaceTypeDeclaration : TypeDeclaration
    {
        public static readonly new InterfaceTypeDeclaration Null = new NullInterfaceTypeDeclaration();
        public readonly static Role<TypeDeclaration> TypeRole = new Role<TypeDeclaration>("Type", TypeDeclaration.Null);

        sealed class NullInterfaceTypeDeclaration : InterfaceTypeDeclaration
        {
            public override bool IsNull
            {
                get
                {
                    return true;
                }
            }

            public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data = default(T))
            {
                return default(S);
            }

            protected internal override bool DoMatch(AstNode other, PatternMatching.Match match)
            {
                return other == null || other.IsNull;
            }
        }

        public InterfaceTypeDeclaration() { }

        public InterfaceTypeDeclaration(TypeDeclaration type)
        {
            this.Type = type;
        }

        public TypeDeclaration Type
        {
            get { return GetChildByRole(TypeRole); }
            set { SetChildByRole(TypeRole, value); }
        }

        public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data = default(T))
        {
            return visitor.VisitInterfaceTypeDeclaration(this, data);
        }

        protected internal override bool DoMatch(AstNode other, PatternMatching.Match match)
        {
            var o = other as EmptyExpression;
            return o != null;
        }
    }
}

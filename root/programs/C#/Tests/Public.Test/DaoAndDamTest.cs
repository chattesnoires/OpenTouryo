﻿//**********************************************************************************
//* Copyright (C) 2007,2014 Hitachi Solutions,Ltd.
//**********************************************************************************

#region Apache License

// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

//**********************************************************************************
//* クラス名        ：CRUDTest.cs
//* クラス日本語名  ：
//*
//* 作成者          ：Rituparna & Santosh
//* 更新履歴        ：
//* 
//*  Date:        Author:        Comments:
//*  ----------  ----------------  -------------------------------------------------
//*  06/13/2014   Rituparna & Santosh      Testcode development for CRUDTest(Framework classes).
//*  06/24/2014   Rituparna & Santosh   Testcode development for CRUDTest(Public classes).
//*  07/02/2014   Santosh               Added code and modified test cases to prevent database changes after running the test cases
//**********************************************************************************
// 型情報
// System
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
// フレームワーク
using Touryo.Infrastructure.Framework.Business;
using Touryo.Infrastructure.Framework.Common;
using Touryo.Infrastructure.Framework.Dao;
using Touryo.Infrastructure.Framework.Exceptions;
using Touryo.Infrastructure.Framework.Presentation;
using Touryo.Infrastructure.Framework.Util;
using Touryo.Infrastructure.Framework.Transmission;
// 業務フレームワーク
using Touryo.Infrastructure.Business.Business;
using Touryo.Infrastructure.Business.Common;
using Touryo.Infrastructure.Business.Dao;
using Touryo.Infrastructure.Business.Exceptions;
using Touryo.Infrastructure.Business.Presentation;
using Touryo.Infrastructure.Business.Util;
// 部品
using Touryo.Infrastructure.Public.Db;
using Touryo.Infrastructure.Public.IO;
using Touryo.Infrastructure.Public.Log;
using Touryo.Infrastructure.Public.Str;
using Touryo.Infrastructure.Public.Util;
//// 型情報
//using BDLayer.Test.Common;
//using BDLayer.Test.Business;
// testing framework
using NUnit.Framework;
using MyType;
using System.Reflection;
using System.Data.SqlClient;

namespace Public.Test
{

    [TestFixture]
    class DaoAndDamTest
    {
        /// <summary>
        /// テスト前処理
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            testList.Clear();
            testList = GetListData();
            Identity = GetIdentityValue();
            Console.WriteLine("これはテスト前処理です。最初に一度だけ実行されます。");
        }

        /// <summary>
        /// テストケース前処理
        /// </summary>
        [SetUp]
        public void SetUp()
        {

            Console.WriteLine("これはテストケース前処理です。テストケースごとに実行されます。");

        }
        /// <summary>
        /// TearDown Method
        /// </summary>
        [TearDown]
        public void TearDown()
        {

        }
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //Executes Last after all tests have run.
            DeleteData();
        }

        List<int> testList = new List<int>();
        int Identity = 0;

        /// <summary>
        /// This method to generate test cases. 
        /// This method to generate test data to be passed to the method SampleScreen_CRUD_Test.
        /// </summary>
        public IEnumerable<TestCaseData> TestSampleScreen_DaoAndDam_Test
        {
            get
            {

                /*SelectCount*/
                yield return new TestCaseData("TestID-000N", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "RC", null, null, null);
                yield return new TestCaseData("TestID-001N", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", null, null, null);
                yield return new TestCaseData("TestID-002N", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "RC", null, null, null);
                yield return new TestCaseData("TestID-003N", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", null, null, null);
                yield return new TestCaseData("TestID-004A", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-005A", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-006A", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-007A", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-008N", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "NT", null, null, null);
                yield return new TestCaseData("TestID-009N", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "NT", null, null, null);
                yield return new TestCaseData("TestID-010N", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "NT", null, null, null);
                yield return new TestCaseData("TestID-011N", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "NT", null, null, null);
                yield return new TestCaseData("TestID-012N", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "RU", null, null, null);
                yield return new TestCaseData("TestID-013N", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", null, null, null);
                yield return new TestCaseData("TestID-014N", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "RU", null, null, null);
                yield return new TestCaseData("TestID-015N", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "RU", null, null, null);
                yield return new TestCaseData("TestID-016N", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "RR", null, null, null);
                yield return new TestCaseData("TestID-017N", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "RR", null, null, null);
                yield return new TestCaseData("TestID-018N", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "RR", null, null, null);
                yield return new TestCaseData("TestID-019N", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "RR", null, null, null);
                yield return new TestCaseData("TestID-020A", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-021A", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-022A", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-023A", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-036N", "screen1", "control1", "SelectCount", "SQL%individual%static%-", "User1", "Hostname1", "DF", null, null, null);
                yield return new TestCaseData("TestID-037N", "screen2", "control2", "SelectCount", "SQL%individual%dynamic%-", "User2", "Hostname2", "DF", null, null, null);
                yield return new TestCaseData("TestID-038N", "screen3", "control3", "SelectCount", "SQL%common%static%-", "User3", "Hostname3", "DF", null, null, null);
                yield return new TestCaseData("TestID-039N", "screen4", "control4", "SelectCount", "SQL%common%dynamic%-", "User4", "Hostname4", "DF", null, null, null);
                yield return new TestCaseData("TestID-040A", "screen6", "control6", "SelectCount", "", "", "", "DF", null, null, null).Throws(typeof(IndexOutOfRangeException));
                /*SelectCount*/

                /*SelectAll_DT*/
                yield return new TestCaseData("TestID-041N", "screen1", "control1", "SelectAll_DT", "SQL%individual%static%-", "User1", "Hostname1", "RC", null, null, null);
                yield return new TestCaseData("TestID-042N", "screen2", "control2", "SelectAll_DT", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", null, null, null);
                yield return new TestCaseData("TestID-043N", "screen3", "control3", "SelectAll_DT", "SQL%common%static%-", "User3", "Hostname3", "RC", null, null, null);
                yield return new TestCaseData("TestID-044N", "screen4", "control4", "SelectAll_DT", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", null, null, null);
                yield return new TestCaseData("TestID-045A", "screen1", "control1", "SelectAll_DT", "SQL%individual%static%-", "User1", "Hostname1", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-046A", "screen2", "control2", "SelectAll_DT", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-047A", "screen3", "control3", "SelectAll_DT", "SQL%common%static%-", "User3", "Hostname3", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-048A", "screen4", "control4", "SelectAll_DT", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-049N", "screen1", "control1", "SelectAll_DT", "SQL%individual%static%-", "User1", "Hostname1", "NT", null, null, null);
                yield return new TestCaseData("TestID-050N", "screen2", "control2", "SelectAll_DT", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", null, null, null);
                yield return new TestCaseData("TestID-051N", "screen3", "control3", "SelectAll_DT", "SQL%common%static%-", "User3", "Hostname3", "RR", null, null, null);
                yield return new TestCaseData("TestID-052N", "screen4", "control4", "SelectAll_DT", "SQL%common%dynamic%-", "User4", "Hostname4", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-053N", "screen1", "control4", "", "SQL%generate%static%-", "User5", "Hostname5", "DF", null, null, null);
                yield return new TestCaseData("TestID-054N", "screen1", "control4", "", "", "User5", "Hostname5", "DF", null, null, null);
                yield return new TestCaseData("TestID-055N", "", "control4", "", "", "User5", "Hostname5", "RC", null, null, null);
                /*SelectAll_DT*/

                /*SelectAll_DR*/
                yield return new TestCaseData("TestID-056N", "screen1", "control1", "SelectAll_DR", "SQL%individual%static%-", "User1", "Hostname1", "RC", null, null, null);
                yield return new TestCaseData("TestID-057N", "screen2", "control2", "SelectAll_DR", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", null, null, null);
                yield return new TestCaseData("TestID-058N", "screen3", "control3", "SelectAll_DR", "SQL%common%static%-", "User3", "Hostname3", "RC", null, null, null);
                yield return new TestCaseData("TestID-059N", "screen4", "control4", "SelectAll_DR", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", null, null, null);


                yield return new TestCaseData("TestID-060A", "screen1", "control1", "SelectAll_DR", "SQL%individual%static%-", "User1", "Hostname1", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-061A", "screen2", "control2", "SelectAll_DR", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-062A", "screen3", "control3", "SelectAll_DR", "SQL%common%static%-", "User3", "Hostname3", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-063A", "screen4", "control4", "SelectAll_DR", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-063N", "screen1", "control1", "SelectAll_DR", "SQL%individual%static%-", "User1", "Hostname1", "NT", null, null, null);
                yield return new TestCaseData("TestID-064N", "screen2", "control2", "SelectAll_DR", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", null, null, null);
                yield return new TestCaseData("TestID-065N", "screen3", "control3", "SelectAll_DR", "SQL%common%static%-", "User3", "Hostname3", "RR", null, null, null);
                yield return new TestCaseData("TestID-066N", "screen4", "control4", "SelectAll_DR", "SQL%individual%static%-", "User4", "Hostname4", "SS", null, null, null).Throws(typeof(System.InvalidOperationException));
                yield return new TestCaseData("TestID-067N", "screen1", "control4", "", "", "User5", "Hostname5", "DF", null, null, null);
                yield return new TestCaseData("TestID-068N", "", "control4", "", "", "User5", "Hostname5", "RC", null, null, null);
                /*SelectAll_DR*/

                /*SelectAll_DSQL*/
                yield return new TestCaseData("TestID-069N", "screen1", "control1", "SelectAll_DSQL", "SQL%individual%static%-", "User1", "Hostname1", "RC", null, null, null);
                yield return new TestCaseData("TestID-070N", "screen2", "control2", "SelectAll_DSQL", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", null, null, null);
                yield return new TestCaseData("TestID-071N", "screen3", "control3", "SelectAll_DSQL", "SQL%common%static%-", "User3", "Hostname3", "RC", null, null, null);
                yield return new TestCaseData("TestID-072N", "screen4", "control4", "SelectAll_DSQL", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", null, null, null);
                yield return new TestCaseData("TestID-073A", "screen1", "control1", "SelectAll_DSQL", "SQL%individual%static%-", "User1", "Hostname1", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-074A", "screen2", "control2", "SelectAll_DSQL", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-075A", "screen3", "control3", "SelectAll_DSQL", "SQL%common%static%-", "User3", "Hostname3", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-076A", "screen4", "control4", "SelectAll_DSQL", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-077N", "screen1", "control1", "SelectAll_DSQL", "SQL%individual%static%-", "User1", "Hostname1", "NT", null, null, null);
                yield return new TestCaseData("TestID-078N", "screen2", "control2", "SelectAll_DSQL", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", null, null, null);
                yield return new TestCaseData("TestID-079N", "screen3", "control3", "SelectAll_DSQL", "SQL%common%static%-", "User3", "Hostname3", "RR", null, null, null);
                yield return new TestCaseData("TestID-080N", "screen4", "control4", "SelectAll_DSQL", "SQL%common%dynamic%-", "User4", "Hostname4", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-081N", "screen1", "control4", "", "", "User5", "Hostname5", "DF", null, null, null);
                yield return new TestCaseData("TestID-082N", "", "control4", "", "", "User5", "Hostname5", "RC", null, null, null);
                /*SelectAll_DSQL*/

                /*SelectAll_DS*/
                yield return new TestCaseData("TestID-083N", "screen1", "control1", "SelectAll_DS", "SQL%individual%static%-", "User1", "Hostname1", "RC", null, null, null);
                yield return new TestCaseData("TestID-084N", "screen2", "control2", "SelectAll_DS", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", null, null, null);
                yield return new TestCaseData("TestID-085N", "screen3", "control3", "SelectAll_DS", "SQL%common%static%-", "User3", "Hostname3", "RC", null, null, null);
                yield return new TestCaseData("TestID-086N", "screen4", "control4", "SelectAll_DS", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", null, null, null);
                yield return new TestCaseData("TestID-087A", "screen1", "control1", "SelectAll_DS", "SQL%individual%static%-", "User1", "Hostname1", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-088A", "screen2", "control2", "SelectAll_DS", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-089A", "screen3", "control3", "SelectAll_DS", "SQL%common%static%-", "User3", "Hostname3", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-090A", "screen4", "control4", "SelectAll_DS", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", null, null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-091N", "screen1", "control1", "SelectAll_DS", "SQL%individual%static%-", "User1", "Hostname1", "NT", null, null, null);
                yield return new TestCaseData("TestID-092N", "screen2", "control2", "SelectAll_DS", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", null, null, null);
                yield return new TestCaseData("TestID-093N", "screen3", "control3", "SelectAll_DS", "SQL%common%static%-", "User3", "Hostname3", "RR", null, null, null);
                yield return new TestCaseData("TestID-094N", "screen4", "control4", "SelectAll_DS", "SQL%common%dynamic%-", "User4", "Hostname4", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-095N", "screen1", "control4", "", "", "User5", "Hostname5", "DF", null, null, null);
                yield return new TestCaseData("TestID-096N", "", "control4", "", "", "User5", "Hostname5", "RC", null, null, null);
                /*SelectAll_DS*/

                /*Select*/
                yield return new TestCaseData("TestID-097N", "screen1", "control1", "Select", "SQL%individual%static%-", "User1", "Hostname1", "RC", "1", null, null);
                yield return new TestCaseData("TestID-098N", "screen2", "control2", "Select", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", "2", null, null);
                yield return new TestCaseData("TestID-099N", "screen3", "control3", "Select", "SQL%common%static%-", "User3", "Hostname3", "RC", "3", null, null);
                yield return new TestCaseData("TestID-100A", "screen4", "control4", "Select", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", "1", null, null);
                yield return new TestCaseData("TestID-101A", "screen1", "control1", "Select", "SQL%individual%static%-", "User1", "Hostname1", "NC", "1", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-102A", "screen2", "control2", "Select", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", "1", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-103A", "screen3", "control3", "Select", "SQL%common%static%-", "User3", "Hostname3", "NC", "1", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-104A", "screen4", "control4", "Select", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", "2", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-105N", "screen1", "control1", "Select", "SQL%individual%static%-", "User1", "Hostname1", "NT", "1", null, null);
                yield return new TestCaseData("TestID-106N", "screen2", "control2", "Select", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", "3", null, null);
                yield return new TestCaseData("TestID-107N", "screen3", "control3", "Select", "SQL%common%static%-", "User3", "Hostname3", "RR", "2", null, null);
                yield return new TestCaseData("TestID-108N", "screen4", "control4", "Select", "SQL%common%dynamic%-", "User4", "Hostname4", "SS", "1", null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-109N", "screen1", "control4", "", "", "User5", "Hostname5", "DF", "1", null, null);
                yield return new TestCaseData("TestID-110N", "", "control4", "", "", "User5", "Hostname5", "RC", "1", null, null);
                /*Select*/


                /*Insert*/
                this.Init();
                this.SetUp();
                yield return new TestCaseData("TestID-111N", "screen1", "control1", "Insert", "SQL%individual%static%-", "User1", "Hostname1", "RC", null, "Hitachi", "00180099666");
                yield return new TestCaseData("TestID-112N", "screen2", "control2", "Insert", "SQL%individual%dynamic%-", "User2", "Hostname2", "RC", null, "Hitachi1", "001800996662");
                yield return new TestCaseData("TestID-113N", "screen3", "control3", "Insert", "SQL%common%static%-", "User3", "Hostname3", "RC", "4", "Hitachi2", "001800996626");
                yield return new TestCaseData("TestID-114A", "screen4", "control4", "Insert", "SQL%common%dynamic%-", "User4", "Hostname4", "RC", "5", "Hitachi4", "001800996626");
                yield return new TestCaseData("TestID-115A", "screen1", "control1", "Insert", "SQL%individual%static%-", "User1", "Hostname1", "NC", "1", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-116A", "screen2", "control2", "Insert", "SQL%individual%dynamic%-", "User2", "Hostname2", "NC", "1", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-117A", "screen3", "control3", "Insert", "SQL%common%static%-", "User3", "Hostname3", "NC", "1", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-118A", "screen4", "control4", "Insert", "SQL%common%dynamic%-", "User4", "Hostname4", "NC", "2", null, null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-119N", "screen1", "control1", "Insert", "SQL%individual%static%-", "User1", "Hostname1", "NT", "6", "Hitachi5", "001800996626");
                yield return new TestCaseData("TestID-120N", "screen2", "control2", "Insert", "SQL%individual%dynamic%-", "User2", "Hostname2", "RU", null, "Hitachi6", "001800996626");
                yield return new TestCaseData("TestID-121N", "screen3", "control3", "Insert", "SQL%common%static%-", "User3", "Hostname3", "RR", "7", "Hitachi7", "001800996626");
                yield return new TestCaseData("TestID-122N", "screen4", "control4", "Insert", "SQL%common%dynamic%-", "User4", "Hostname4", "SS", null, null, null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-123N", "screen1", "control4", "", "", "User5", "Hostname5", "DF", "9", null, null);
                yield return new TestCaseData("TestID-124N", "", "control4", "", "", "User5", "Hostname5", "RC", "10", null, null);

                /* Update*/
                yield return new TestCaseData("TestID-125N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "RC", (Identity + 1).ToString(), "Company_NameUpdate", "125987");
                yield return new TestCaseData("TestID-126N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "RC", (Identity + 2).ToString(), "Company_NameUpdate", "987456");
                yield return new TestCaseData("TestID-127N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "RC", (Identity + 3).ToString(), "Company_NameUpdate", "125987");
                yield return new TestCaseData("TestID-128N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "RC", (Identity + 4).ToString(), "Company_NameUpdate", "");
                yield return new TestCaseData("TestID-129A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "RC", (Identity + 1).ToString(), "Company_NameUpdate", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-130A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "RC", (Identity + 1).ToString(), null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-131A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "RC", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-132A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "RC", null, null, null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-133A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "RC", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-134A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-135A", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "NC", (Identity + 1).ToString(), "Company_NameUpdate", "125987").Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-136A", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "NC", (Identity + 2).ToString(), "Company2_update", "987456").Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-137A", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "NC", (Identity + 3).ToString(), "", "125987").Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-138A", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "NC", (Identity + 4).ToString(), "Company3_update", "").Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-139A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "NC", (Identity + 5).ToString(), "Company1_update", null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-140A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "NC", (Identity + 6).ToString(), null, "20042360").Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-141A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "NC", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-142A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "NC", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-143A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "NC", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-144A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "NC", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-145N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "NT", (Identity + 1).ToString(), "Company_NameUpdated", "125987");
                yield return new TestCaseData("TestID-146N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "NT", (Identity + 4).ToString(), "Company_NameUpdated", "987456");
                yield return new TestCaseData("TestID-147N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "NT", (Identity + 5).ToString(), "", "125987");
                yield return new TestCaseData("TestID-148N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "NT", (Identity + 6).ToString(), "Company_NameUpdated", "");
                yield return new TestCaseData("TestID-149A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "NT", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-150A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "NT", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-151A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "NT", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-152A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "NT", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-153A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "NT", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-154A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "NT", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-155N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "RU", (Identity + 1).ToString(), "Company_NameUpdated", "125987");
                yield return new TestCaseData("TestID-156N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "RU", (Identity + 1).ToString(), "Company_NameUpdated", "987456");
                yield return new TestCaseData("TestID-157N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "RU", (Identity + 1).ToString(), "", "125987");
                yield return new TestCaseData("TestID-158N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "RU", (Identity + 1).ToString(), "Company_NameUpdated", "");
                yield return new TestCaseData("TestID-159A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "RU", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-160A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "RU", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-161A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "RU", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-162A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "RU", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-163A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "RU", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-164A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "RU", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-165N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "RU", (Identity + 1).ToString(), "Company_NameUpdated", "125987");
                yield return new TestCaseData("TestID-166N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "RU", (Identity + 7).ToString(), "Company_NameUpdated", "987456");
                yield return new TestCaseData("TestID-167N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "RU", (Identity + 9).ToString(), "", "125987");
                yield return new TestCaseData("TestID-168N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "RU", (Identity + 10).ToString(), "Company_NameUpdated", "");
                yield return new TestCaseData("TestID-169A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "RU", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-170A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "RU", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-171A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "RU", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-172A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "RU", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-173A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "RU", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-174A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "RU", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-175N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "RR", (Identity + 1).ToString(), "Company_NameUpdated", "125987");
                yield return new TestCaseData("TestID-176N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "RR", (Identity + 2).ToString(), "Company_NameUpdated", "987456");
                yield return new TestCaseData("TestID-177N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "RR", (Identity + 8).ToString(), "", "125987");
                yield return new TestCaseData("TestID-178N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "RR", (Identity + 1).ToString(), "Company_NameUpdated", "");
                yield return new TestCaseData("TestID-179A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "RR", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-180A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "RR", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-181A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "RR", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-182A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "RR", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-183A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "RR", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-184A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "RR", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-185N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "SZ", (Identity + 1).ToString(), "Company_NameUpdated", "125987");
                yield return new TestCaseData("TestID-186N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "SZ", (Identity + 7).ToString(), "Company_NameUpdated", "987456");
                yield return new TestCaseData("TestID-187N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "SZ", (Identity + 6).ToString(), "", "125987");
                yield return new TestCaseData("TestID-188N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "SZ", (Identity + 15).ToString(), "Company_NameUpdated", "");
                yield return new TestCaseData("TestID-189A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "SZ", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-190A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "SZ", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-200A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "SZ", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-201A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "SZ", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-202A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "SZ", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-203", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "SZ", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-204A", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "SS", "1", "Company1_update", "125987").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-205A", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "SS", "2", "Company2_update", "987456").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-206A", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "SS", "3", "", "125987").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-207A", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "SS", "3", "Company3_update", "").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-208A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "SS", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-209A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "SS", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-210A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "SS", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-211A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "SS", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-212A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "SS", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-213A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "SS", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-214N", "screen1", "control1", "Update", "SQL%individual%static%-", "User1", "Hostname1", "DF", (Identity + 1).ToString(), "Company_NameUpdated", "125987");
                yield return new TestCaseData("TestID-215N", "screen2", "control2", "Update", "SQL%individual%static%-", "User2", "Hostname2", "DF", (Identity + 2).ToString(), "Company_NameUpdated", "987456");
                yield return new TestCaseData("TestID-216N", "screen3", "control3", "Update", "SQL%individual%static%-", "User3", "Hostname3", "DF", (Identity + 3).ToString(), "", "125987");
                yield return new TestCaseData("TestID-217N", "screen4", "control4", "Update", "SQL%individual%static%-", "User4", "Hostname4", "DF", (Identity + 4).ToString(), "Company_NameUpdated", "");
                yield return new TestCaseData("TestID-218A", "screen5", "control5", "Update", "SQL%individual%static%-", "User5", "Hostname5", "DF", "1", "Company1_update", null).Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-219A", "screen6", "control6", "Update", "SQL%individual%static%-", "User6", "Hostname6", "DF", "1", null, "20042360").Throws(typeof(System.Data.SqlClient.SqlException));
                yield return new TestCaseData("TestID-220A", "screen7", "control7", "Update", "SQL%individual%static%-", "User7", "Hostname7", "DF", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-221A", "screen8", "control8", "Update", "SQL%individual%static%-", "User8", "Hostname8", "DF", null, null, null).Throws(typeof(ArgumentNullException)); ;
                yield return new TestCaseData("TestID-222A", "screen9", "control9", "Update", "SQL%individual%static%-", "User9", "Hostname9", "DF", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                yield return new TestCaseData("TestID-223A", "screen10", "control10", "Update", "SQL%individual%static%-", "User10", "Hostname10", "DF", "12N", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                /* Update*/

                /*Delete*/
                yield return new TestCaseData("TestID-224N", "screen1", "control1", "Delete", "SQL%individual%static%-", "User1", "Hostname1", "NT", (Identity + 5).ToString(), "Hitachi", "125987");
                yield return new TestCaseData("TestID-225N", "screen2", "control2", "Delete", "SQL%individual%static%-", "User2", "Hostname2", "NT", (Identity + 6).ToString(), "Hitachi", "987456");
                yield return new TestCaseData("TestID-226N", "screen3", "control3", "Delete", "SQL%individual%static%-", "User3", "Hostname3", "NT", (Identity + 7).ToString(), "", "125987");
                yield return new TestCaseData("TestID-227N", "screen4", "control4", "Delete", "SQL%individual%static%-", "User4", "Hostname4", "NT", (Identity + 8).ToString(), "HiSOL", "");
                yield return new TestCaseData("TestID-228A", "screen5", "control5", "Delete", "SQL%individual%static%-", "User5", "Hostname5", "NC", (Identity + 4).ToString(), "Company1_update", null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-229A", "screen6", "control6", "Delete", "SQL%individual%static%-", "User6", "Hostname6", "NC", (Identity + 9).ToString(), null, "20042360").Throws(typeof(NullReferenceException));
                yield return new TestCaseData("TestID-230A", "screen7", "control7", "Delete", "SQL%individual%static%-", "User7", "Hostname7", "RC", null, "Company1_update", "20042360").Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-231A", "screen8", "control8", "Delete", "SQL%individual%static%-", "User8", "Hostname8", "RC", null, null, null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData("TestID-232A", "screen9", "control9", "Delete", "SQL%individual%static%-", "User9", "Hostname9", "RC", "", "Company1_update", "20042360").Throws(typeof(System.FormatException));
                /*Delete*/

                /*SelectJoin1*/
                yield return new TestCaseData("TestID-234N", "screen10", "control10", "SelectJoin1", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "");
                yield return new TestCaseData("TestID-235N", "screen10", "control10", "SelectJoin1", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-236N", "screen10", "control10", "SelectJoin1", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                /*SelectJoin*/

                /*SelectJoin2*/
                yield return new TestCaseData("TestID-237N", "screen10", "control10", "SelectJoin2", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "");
                yield return new TestCaseData("TestID-238N", "screen10", "control10", "SelectJoin2", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-239N", "screen10", "control10", "SelectJoin2", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                /*SelectJoin2*/

                /*testSqlsvr4c*/
                yield return new TestCaseData("TestID-240N", "screen10", "control10", "TestSqlsvr4c", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "");
                yield return new TestCaseData("TestID-241N", "screen10", "control10", "TestSqlsvr4c", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-242N", "screen10", "control10", "TestSqlsvr4c", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                /*testSqlsvr4c*/

                /*testSqlsvr4b*/
                yield return new TestCaseData("TestID-243N", "screen10", "control10", "TestSqlsvr4b", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "");
                yield return new TestCaseData("TestID-244N", "screen10", "control10", "TestSqlsvr4b", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-245N", "screen10", "control10", "TestSqlsvr4b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                /*testSqlsvr4b*/

                /*testSqlsvr4a*/
                yield return new TestCaseData("TestID-246N", "screen10", "control10", "TestSqlsvr4a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "");
                yield return new TestCaseData("TestID-247N", "screen10", "control10", "TestSqlsvr4a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-248N", "screen10", "control10", "TestSqlsvr4a", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                /*testSqlsvr4a*/

                /*List*/
                yield return new TestCaseData("TestID-249N", "screen10", "control10", "check_7a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360");
                yield return new TestCaseData("TestID-250N", "screen10", "control10", "check_7a", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360");
                yield return new TestCaseData("TestID-251N", "screen10", "control10", "check_7a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360");

                yield return new TestCaseData("TestID-252N", "screen10", "control10", "check_11a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360");
                yield return new TestCaseData("TestID-253N", "screen10", "control10", "check_11a", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360");
                yield return new TestCaseData("TestID-254N", "screen10", "control10", "check_11a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360");

                yield return new TestCaseData("TestID-255A", "screen10", "control10", "check_11c", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360").Throws(typeof(ArgumentException));
                yield return new TestCaseData("TestID-256A", "screen10", "control10", "check_11c", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360").Throws(typeof(ArgumentException));
                yield return new TestCaseData("TestID-257A", "screen10", "control10", "check_11c", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "symphony", "20042360").Throws(typeof(ArgumentException));
                /*List*/

                // Select Case
                yield return new TestCaseData("TestID-258N", "screen10", "control10", "SelectCase1a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-259N", "screen10", "control10", "SelectCase1b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-260N", "screen10", "control10", "SelectCase2a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-261N", "screen10", "control10", "SelectCase2b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-262N", "screen10", "control10", "SelectCase3a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-263N", "screen10", "control10", "SelectCase3b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-264N", "screen10", "control10", "SelectCase4a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-265N", "screen10", "control10", "SelectCase4b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");

                //Select Case Default
                yield return new TestCaseData("TestID-266N", "screen10", "control10", "SelectCaseDefault1a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-267N", "screen10", "control10", "SelectCaseDefault1b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-268N", "screen10", "control10", "SelectCaseDefault2a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-269N", "screen10", "control10", "SelectCaseDefault2b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-270N", "screen10", "control10", "SelectCaseDefault3a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-271N", "screen10", "control10", "SelectCaseDefault3b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-272N", "screen10", "control10", "SelectCaseDefault4a", "SQL%common%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-273N", "screen10", "control10", "SelectCaseDefault4b", "SQL%common%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");

                //D layer Execution
                yield return new TestCaseData("TestID-274N", "screen10", "control10", "SelectCaseDefault1a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-275N", "screen10", "control10", "SelectCaseDefault1b", "SQL%individual%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-276N", "screen10", "control10", "SelectCaseDefault2a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-277N", "screen10", "control10", "SelectCaseDefault2b", "SQL%individual%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-278N", "screen10", "control10", "SelectCaseDefault3a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-279N", "screen10", "control10", "SelectCaseDefault3b", "SQL%individual%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-280N", "screen10", "control10", "SelectCaseDefault4a", "SQL%individual%static%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");
                yield return new TestCaseData("TestID-281N", "screen10", "control10", "SelectCaseDefault4b", "SQL%individual%dynamic%-", "User10", "Hostname10", "RC", "12N", "Company1_update", "20042360");

            }
        }

        #region TestCode
        /// <summary>CallBusinessLogic Method</summary>
        /// <param name="TestCaseID">Test case ID</param>
        /// <param name="screen">screen ID</param>
        /// <param name="buttonID">Button ID</param>
        /// <param name="action">Control action name</param>
        /// <param name="dbGeneration">Db Generation</param>
        /// <param name="user">User Info</param>
        /// <param name="ipAddress">Ip address</param>
        /// <param name="isolationLevel">Isolation level</param>
        /// <param name="testParameterValue">Test Parameter values</param>
        /// <param name="shipperID">Shipper Id</param>
        /// <param name="companyName">Company name</param>
        /// <param name="phone">Phone Number</param>
        [TestCaseSource("TestSampleScreen_DaoAndDam_Test")]
        public void SampleScreen_DaoAndDam_Test(string TestCaseID, string screen, string buttonID, string action, string dbGeneration, string user, string ipAddress,
                                           string isolationLevel, string shipperID, string companyName, string phone)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            // 引数クラスを生成
            // 下位（Ｂ・Ｄ層）は、テスト クラスを流用する
            MyUserInfo userInfo = new MyUserInfo(user, ipAddress);
            TestParameterValue testParameterValue
                 = new TestParameterValue(
                     screen, buttonID, action,
                     dbGeneration,
                    userInfo);
            TestReturnValue resultTestReturnValue;
            TestReturnValue expectedTestReturnValue;
            DataSet expectedDataSet = new DataSet();
            DataSet resultDataSet = new DataSet();
            //Assert conditions
            switch (action)
            {
                case "SelectCount":
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                      out expectedTestReturnValue);
                    Assert.AreEqual(resultTestReturnValue.Obj.ToString(), expectedTestReturnValue.Obj.ToString());
                    break;
                case "SelectAll_DT":
                case "SelectAll_DR":
                case "SelectAll_DSQL":
                    testParameterValue.OrderColumn = "c1";
                    testParameterValue.OrderSequence = "A";
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);
                    DataTable expectedDataTable = (DataTable)expectedTestReturnValue.Obj;
                    DataTable resultDataTable = (DataTable)resultTestReturnValue.Obj;
                    if (!resultTestReturnValue.ErrorFlag)
                        Assert.AreEqual(expectedDataTable.Rows.Count, resultDataTable.Rows.Count);
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "SelectAll_DS":
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);
                    expectedDataSet = (DataSet)expectedTestReturnValue.Obj;
                    resultDataSet = (DataSet)resultTestReturnValue.Obj;
                    if (!resultTestReturnValue.ErrorFlag)
                        Assert.AreEqual(resultDataSet.Tables.Count, expectedDataSet.Tables.Count);
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "Select":
                    testParameterValue.OrderColumn = "c1";
                    testParameterValue.OrderSequence = "A";
                    testParameterValue.ShipperID = 1;
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);
                    if (!resultTestReturnValue.ErrorFlag)
                    {
                        Assert.AreEqual(resultTestReturnValue.ShipperID, expectedTestReturnValue.ShipperID);
                        Assert.AreEqual(resultTestReturnValue.Phone, expectedTestReturnValue.Phone);
                        Assert.AreEqual(resultTestReturnValue.CompanyName, expectedTestReturnValue.CompanyName);
                    }
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "Insert":
                    testParameterValue.CompanyName = companyName;
                    testParameterValue.Phone = phone;
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);

                    if (!resultTestReturnValue.ErrorFlag)
                    {
                        Assert.AreEqual(resultTestReturnValue.Obj.ToString(), expectedTestReturnValue.Obj.ToString());
                    }
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;

                case "Update":
                    testParameterValue.ShipperID = int.Parse(shipperID);
                    testParameterValue.CompanyName = companyName;
                    testParameterValue.Phone = phone;
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);
                    if (!resultTestReturnValue.ErrorFlag)
                    {
                        Assert.AreEqual(resultTestReturnValue.Obj.ToString(), expectedTestReturnValue.Obj.ToString());
                    }
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "Delete":
                    // 情報の設定
                    testParameterValue.ShipperID = int.Parse(shipperID);
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);
                    if (!resultTestReturnValue.ErrorFlag)
                    {
                        if (resultTestReturnValue.Obj.ToString() == "1")
                        {
                            Assert.AreEqual(resultTestReturnValue.Obj.ToString(), "1");
                        }
                        else
                        {
                            Assert.AreEqual(resultTestReturnValue.Obj.ToString(), "0");
                        }
                    }
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "SelectJoin1":
                case "SelectJoin2":
                case "TestSqlsvr4c":
                case "TestSqlsvr4b":
                case "TestSqlsvr4a":
                    testParameterValue.CompanyName = companyName;
                    testParameterValue.OrderColumn = "c1";
                    testParameterValue.OrderSequence = "A";
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue, out resultTestReturnValue,
                                     out expectedTestReturnValue);
                    expectedDataSet = (DataSet)expectedTestReturnValue.Obj;
                    resultDataSet = (DataSet)resultTestReturnValue.Obj;
                    if (!resultTestReturnValue.ErrorFlag)
                        Assert.AreEqual(resultDataSet.Tables.Count, expectedDataSet.Tables.Count);
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "SelectCase1a":
                case "SelectCase1b":
                case "SelectCase2a":
                case "SelectCase2b":
                case "SelectCase3a":
                case "SelectCase3b":
                case "SelectCase4a":
                case "SelectCase4b":
                case "SelectCaseDefault1a":
                case "SelectCaseDefault1b":
                case "SelectCaseDefault2a":
                case "SelectCaseDefault2b":
                case "SelectCaseDefault3a":
                case "SelectCaseDefault3b":
                case "SelectCaseDefault4a":
                case "SelectCaseDefault4b":
                    TestParameterValue testParameterValue1
                 = new TestParameterValue(
                     screen, buttonID, "SelectCase",
                     dbGeneration,
                    userInfo);
                    testParameterValue1.SelectCase = action;
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue1, out resultTestReturnValue,
                                   out expectedTestReturnValue);
                    DataTable expectedDatatable = (DataTable)expectedTestReturnValue.Obj;
                    DataTable resultDatatable = (DataTable)resultTestReturnValue.Obj;
                    if (!resultTestReturnValue.ErrorFlag)
                        Assert.AreEqual(expectedDatatable.Rows.Count, resultDatatable.Rows.Count);
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
                case "check_7a":
                case "check_11a":
                case "check_11c":
                    TestParameterValue testParameterValue2
                = new TestParameterValue(
                    screen, buttonID, "check",
                    dbGeneration,
                   userInfo);
                    testParameterValue2.check = action;
                    CallBusinessLogic(screen, buttonID, action, dbGeneration, user, ipAddress, isolationLevel, testParameterValue2, out resultTestReturnValue,
                                  out expectedTestReturnValue);
                    expectedDataSet = (DataSet)expectedTestReturnValue.Obj;
                    resultDataSet = (DataSet)resultTestReturnValue.Obj;
                    if (!resultTestReturnValue.ErrorFlag)
                        Assert.AreEqual(expectedDataSet.Tables.Count, resultDataSet.Tables.Count);
                    else
                        Assert.AreEqual(resultTestReturnValue.ErrorFlag, true);
                    break;
            }
            //}
        }

        #region CallBusinessLogic
        /// <summary>CallBusinessLogic Method</summary>
        /// <param name="screen">screen ID</param>
        /// <param name="buttonID">Button ID</param>
        /// <param name="action">Control action name</param>
        /// <param name="dbGeneration">Db Generation</param>
        /// <param name="user">User Info</param>
        /// <param name="ipAddress">Ip address</param>
        /// <param name="isolationLevel">Isolation level</param>
        /// <param name="testParameterValue">Test Parameter values</param>
        /// <returns>resultTestReturnValue</returns>
        /// <returns>expectedTestReturnValue</returns>
        private void CallBusinessLogic(string screen, string buttonID, string action, string dbGeneration, string user, string ipAddress, string isolationLevel, TestParameterValue testParameterValue, out TestReturnValue resultTestReturnValue, out TestReturnValue expectedTestReturnValue)
        {
            // 分離レベルの設定
            DbEnum.IsolationLevelEnum iso = SelectIsolationLevel(isolationLevel);

            // B層を生成
            LayerB myBusiness = new LayerB();

            // 業務処理を実行
            resultTestReturnValue = (TestReturnValue)myBusiness.DoBusinessLogic((BaseParameterValue)testParameterValue, iso);
            expectedTestReturnValue = (TestReturnValue)myBusiness.DoBusinessLogic((BaseParameterValue)testParameterValue, iso);
        }
        #endregion

        #region SelectIsolationLevel

        /// <summary>分離レベルの設定</summary>
        /// <param name="isolationLevel">分離レベルの指定</param>
        /// <returns>分離レベル列挙型</returns>
        private DbEnum.IsolationLevelEnum SelectIsolationLevel(string isolationLevel)
        {
            if (isolationLevel == "NC")
            {
                return DbEnum.IsolationLevelEnum.NotConnect;
            }
            else if (isolationLevel == "NT")
            {
                return DbEnum.IsolationLevelEnum.NoTransaction;
            }
            else if (isolationLevel == "RU")
            {
                return DbEnum.IsolationLevelEnum.ReadUncommitted;
            }
            else if (isolationLevel == "RC")
            {
                return DbEnum.IsolationLevelEnum.ReadCommitted;
            }
            else if (isolationLevel == "RR")
            {
                return DbEnum.IsolationLevelEnum.RepeatableRead;
            }
            else if (isolationLevel == "SZ")
            {
                return DbEnum.IsolationLevelEnum.Serializable;
            }
            else if (isolationLevel == "SS")
            {
                return DbEnum.IsolationLevelEnum.Snapshot;
            }
            else if (isolationLevel == "DF")
            {
                return DbEnum.IsolationLevelEnum.DefaultTransaction;
            }
            else
            {
                throw new Exception("分離レベルの設定がおかしい");
            }
        }
        #endregion

        /// <summary>
        /// This method to generate test cases. 
        /// This method to generate test data to be passed to the method GetParametersFromPARAMTagTest.
        /// </summary>
        public IEnumerable<TestCaseData> TestParamtag
        {
            get
            {
                yield return new TestCaseData("Testcase01", MakeRelativePathFile() + "select-case1a.dpq.xml", "SQL%individual%static%-");
                yield return new TestCaseData("Testcase02", MakeRelativePathFile() + "select-case1b.dpq.xml", "SQL%individual%static%-");
                yield return new TestCaseData("Testcase03", MakeRelativePathFile() + "select-case2a.dpq.xml", "SQL%individual%static%-");//.Throws(typeof(ArgumentException));
                yield return new TestCaseData("Testcase04", MakeRelativePathFile() + "select-case2b.dpq.xml", "SQL%individual%static%-");
                yield return new TestCaseData("Testcase05", MakeRelativePathFile() + "select-case3a.dpq.xml", "SQL%individual%static%-");
                yield return new TestCaseData("Testcase06", MakeRelativePathFile() + "select-case4b.dpq.xml", "SQL%individual%static%-");
            }
        }

        /// <summary>
        /// GetParametersFromPARAMTagTest Method
        /// </summary>
        /// <param name="TestCaseID">TestCaseID</param>
        /// <param name="filePath">filePath</param>
        /// <param name="dbGeneration">dbGeneration</param>
        [TestCaseSource("TestParamtag")]
        public void GetParametersFromPARAMTagTest(string TestCaseID, string filePath, string dbGeneration)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                GetParam(filePath, out dt, out dt1, dbGeneration);
                Assert.AreEqual(dt.Rows.Count, dt1.Rows.Count);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region GetParam
        /// <summary>
        /// GetParam Method
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="dt">dt</param>
        /// <param name="dt1">dt1</param>
        /// <param name="dbGeneration">dbGeneration</param>
        private void GetParam(string path, out  DataTable dt, out DataTable dt1, string dbGeneration)
        {
            MyUserInfo userInfo = new MyUserInfo("user1", "Hostname");
            LayerB lb = new LayerB();
            TestParameterValue test = new TestParameterValue("screen1", "button1", "GetParametersFromPARAMTag", dbGeneration, userInfo);
            test.Filepath = path;
            TestReturnValue testreturn = (TestReturnValue)lb.DoBusinessLogic((BaseParameterValue)test);
            dt = (DataTable)testreturn.Obj;
            dt1 = (DataTable)testreturn.Obj;

        }
        #endregion

        #region MakeRelativePathFile
        /// <summary>
        /// MakeRelativePathFile Method
        /// </summary>
        /// <returns></returns>
        private static string MakeRelativePathFile()
        {
            try
            {
                return Path.GetFullPath("sql") + "\\";
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion

        #region Methods to revert datbase Changes
        /// <summary>
        /// ToCommaString Method to get the comma(,) Separted string of list of integer 
        /// </summary>
        /// <param name="list">list</param>
        private string ToCommaString(List<int> list)
        {
            if (list.Count <= 0)
                return ("0");
            if (list.Count == 1)
                return (list[0].ToString());
            System.Text.StringBuilder sb = new System.Text.StringBuilder(list[0].ToString());
            for (int x = 1; x < list.Count; x++)
                sb.Append("," + list[x].ToString());
            return (sb.ToString());
        }
        /// <summary>
        /// GetListData() Method to get list of integer of ShipperID in shippers table before running the test cases 
        /// </summary>
        /// <param name="list">list</param>
        /// <returns value="getList">List of Integer data type<int></returns>
        private List<int> GetListData()
        {
            List<int> getList = new List<int>();
            MyUserInfo userInfo = new MyUserInfo("user1", "Hostname");
            LayerB lb = new LayerB();
            TestParameterValue test = new TestParameterValue("Select ShipperID from Shippers", "button1", "GetList", "SQL%individual%static%-", userInfo);
            TestReturnValue testreturn = (TestReturnValue)lb.DoBusinessLogic((BaseParameterValue)test);
            DataTable dt = (DataTable)testreturn.Obj;
            foreach (DataRow dr in dt.Rows)
            {
                getList.Add((int)dr[0]);
            }
            return getList;
        }

        /// <summary>
        /// DeleteData() Method to delete the ShipperID's from shippers table which are inserted while running test cases. 
        /// </summary>
        private void DeleteData()
        {
            MyUserInfo userInfo = new MyUserInfo("user1", "Hostname");
            LayerB lb = new LayerB();
            string strIDdelete = ToCommaString(testList);
            TestParameterValue test = new TestParameterValue("Delete from Shippers where ShipperID not in(" + strIDdelete + ")", "button1", "GetDelete", "SQL%individual%static%-", userInfo);
            TestReturnValue testreturn = (TestReturnValue)lb.DoBusinessLogic((BaseParameterValue)test);
            testList.Clear();
        }
        /// <summary>
        /// GetIdentityValue() Method to get the Current Identity value of Shipper ID column in Shippers table 
        /// </summary>
        /// <returns value="intIdentity">intIdentity as integer data type</returns>
        private int GetIdentityValue()
        {
            int intIdentity = 0;
            MyUserInfo userInfo = new MyUserInfo("user1", "Hostname");
            LayerB lb = new LayerB();
            TestParameterValue test = new TestParameterValue("SELECT IDENT_CURRENT('shippers')", "button1", "GetID", "SQL%individual%static%-", userInfo);
            TestReturnValue testreturn = (TestReturnValue)lb.DoBusinessLogic((BaseParameterValue)test);
            intIdentity = Convert.ToInt16(testreturn.Obj);
            return intIdentity;
        }
        #endregion
    }
}
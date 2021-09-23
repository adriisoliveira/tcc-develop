rror: 'continue' not supported inside 'finally' clause

There is one test for a break that is not in a loop.  The compiler
uses a single data structure to keep track of try-finally and loops,
so we need to be sure that a break is actually inside a loop.  If it
isn't, there should be a syntax error.

   >>> try:
   ...     print 1
   ...     break
   ...     print 2
   ... finally:
   ...     print 3
   Traceback (most recent call last):
     ...
     File "<doctest test.test_syntax[42]>", line 3
   SyntaxError: 'break' outside loop

This should probably raise a better error than a SystemError (or none at all).
In 2.5 there was a missing exception and an assert was triggered in a debug
build.  The number of blocks must be greater than CO_MAXBLOCKS.  SF #1565514

   >>> while 1:
   ...  while 2:
   ...   while 3:
   ...    while 4:
   ...     while 5:
   ...      while 6:
   ...       while 8:
   ...        while 9:
   ...         while 10:
   ...          while 11:
   ...           while 12:
   ...            while 13:
   ...             while 14:
   ...              while 15:
   ...               while 16:
   ...                while 17:
   ...                 while 18:
   ...                  while 19:
   ...                   while 20:
   ...                    while 21:
   ...                     while 22:
   ...                      break
   Traceback (most recent call last):
     ...
   SystemError: too many statically nested blocks

This tests assignment-context; there was a bug in Python 2.5 where compiling
a complex 'if' (one with 'elif') would fail to notice an invalid suite,
leading to spurious errors.

   >>> if 1:
   ...   x() = 1
   ... elif 1:
   ...   pass
   Traceback (most recent call last):
     ...
     File "<doctest test.test_syntax[44]>", line 2
   SyntaxError: can't assign to function call

   >>> if 1:
   ...   pass
   ... elif 1:
   ...   x() = 1
   Traceback (most recent call last):
     ...
     File "<doctest test.test_syntax[45]>", line 4
   SyntaxError: can't assign to function call

   >>> if 1:
   ...   x() = 1
   ... elif 1:
   ...   pass
   ... else:
   ...   pass
   Traceback (most recent call last):
     ...
     File "<doctest test.test_syntax[46]>", line 2
   SyntaxError: can't assign to function call

   >>> if 1:
   ...   pass
   ... elif 1:
   ...   x() = 1
   ... else:
   ...   pass
   Traceback (most recent call last):
     ...
     File "<doctest test.test_syntax[47]>", line 4
   SyntaxError: can't assign to function call

   >>> if 1:
   ...   pass
   ... elif 1:
   ...   pass
   ... else:
   ...   x() = 1
   Traceback (most recent call last):
     ...
     File "<doctest test.test_syntax[48]>", line 6
   SyntaxError: can't assign to function call

>>> f(a=23, a=234)
Traceback (most recent call last):
   ...
  File "<doctest test.test_syntax[49]>", line 1
SyntaxError: keyword argument repeated

>>> del ()
Traceback (most recent call last):
   ...
  File "<doctest test.test_syntax[50]>", line 1
SyntaxError: can't delete ()

>>> {1, 2, 3} = 42
Traceback (most recent call last):
   ...
   File "<doctest test.test_syntax[50]>", line 1
SyntaxError: can't assign to literal

Corner-case that used to crash:

    >>> def f(*xx, **__debug__): pass
    Traceback (most recent call last):
    SyntaxError: cannot assign to __debug__

"""

import re
import unittest
import warnings

from test import test_support

class SyntaxTestCase(unittest.TestCase):

    def _check_error(self, code, errtext,
                     filename="<testcase>", mode="exec", subclass=None):
        """Check that compiling code raises SyntaxError with errtext.

        errtest is a regular expression that must be present in the
        test of the exception raised.  If subclass is specified it
        is the expected subclass of SyntaxError (e.g. IndentationError).
        """
        try:
            compile(code, filename, mode)
        except SyntaxError, err:
            if subclass and not isinstance(err, subclass):
                self.fail("SyntaxError is not a %s" % subclass.__name__)
            mo = re.search(errtext, str(err))
            if mo is None:
                self.fail("%s did not contain '%r'" % (err, errtext,))
        else:
            self.fail("compile() did not raise SyntaxError")

    def test_paren_arg_with_default(self):
        self._check_error("def f((x)=23): pass",
                          "parenthesized arg with default")

    def test_assign_call(self):
        self._check_error("f() = 1", "assign")

    def test_assign_del(self):
        self._check_error("del f()", "delete")

    def test_global_err_then_warn(self):
        # Bug tickler:  The SyntaxError raised for one global statement
        # shouldn't be clobbered by a SyntaxWarning issued for a later one.
        source = re.sub('(?m)^ *:', '', """\
            :def error(a):
            :    global a  # SyntaxError
            :def warning():
            :    b = 1
            :    global b  # SyntaxWarning
            :""")
        warnings.filterwarnings(action='ignore', category=SyntaxWarning)
        self._check_error(source, "global")
        warnings.filters.pop(0)

    def test_break_outside_loop(self):
        self._check_error("break", "outside loop")

    def test_delete_deref(self):
        source = re.sub('(?m)^ *:', '', """\
            :def foo(x):
            :  def bar():
            :    print x
            :  del x
            :""")
        self._check_error(source, "nested scope")

    def test_unexpected_indent(self):
        self._check_error("foo()\n bar()\n", "unexpected indent",
                          subclass=IndentationError)

    def test_no_indent(self):
        self._check_error("if 1:\nfoo()", "expected an indented block",
                          subclass=IndentationError)

    def test_bad_outdent(self):
        self._check_error("if 1:\n  foo()\n bar()",
                          "unindent does not match .* level",
                          subclass=IndentationError)

    def test_kwargs_last(self):
        self._check_error("int(base=10, '2')", "non-keyword arg")

def test_main():
    test_support.run_unittest(SyntaxTestCase)
    from test import test_syntax
    with test_support.check_py3k_warnings(("backquote not supported",
                                             SyntaxWarning)):
        test_support.run_doctest(test_syntax, verbosity=True)

if __name__ == "__main__":
    test_main()
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
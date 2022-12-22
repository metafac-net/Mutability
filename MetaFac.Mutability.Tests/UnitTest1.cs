using FluentAssertions;
using Xunit;

namespace MetaFac.Mutability.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateFrozenFromMutable()
        {
            SampleMutable mutable = new() { Field1 = 123 };
            SampleFreezable freezable = new() { Field1 = 456 };
            freezable.IsFrozen().Should().BeFalse();
            freezable.CopyFrom(mutable);
            freezable.Freeze();
            freezable.IsFrozen().Should().BeTrue();
            freezable.Field1.Should().Be(mutable.Field1);
        }
        [Fact]
        public void CreateFrozenViaExtension()
        {
            SampleMutable mutable = new() { Field1 = 123 };
            SampleFreezable freezable = mutable.Unfrozen<SampleFreezable, ISample>();
            freezable.IsFrozen().Should().BeFalse();
            freezable.Freeze();
            freezable.IsFrozen().Should().BeTrue();
            freezable.Field1.Should().Be(mutable.Field1);
        }
        [Fact]
        public void CreateFrozenViaCloning()
        {
            SampleFreezable orig = new SampleFreezable() { Field1 = 123 }.Frozen();
            SampleFreezable copy = orig.Unfrozen().Frozen();
            copy.IsFrozen().Should().BeTrue();
            copy.Field1.Should().Be(orig.Field1);
            copy.Equals(orig).Should().BeTrue();
        }
#if NET5_0_OR_GREATER
        [Fact]
        public void CreateRecordViaCloning()
        {
            SampleRecord orig = new() { Field1 = 123 };
            SampleRecord copy = new(orig);
            copy.IsFrozen().Should().BeTrue();
            copy.Field1.Should().Be(orig.Field1);
            copy.Equals(orig).Should().BeTrue();
            copy.Should().Be(orig);
        }
        [Fact]
        public void CreateRecordFromFreezable()
        {
            SampleFreezable orig = new SampleFreezable() { Field1 = 123 };
            orig = orig.Frozen();
            SampleRecord copy = new(orig);
            copy.IsFrozen().Should().BeTrue();
            copy.Field1.Should().Be(orig.Field1);
        }
#endif
    }
}
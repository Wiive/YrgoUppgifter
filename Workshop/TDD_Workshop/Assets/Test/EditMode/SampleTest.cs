using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SampleTest
{

    Health health;

    [SetUp]
    public void SetUp()
    {
        health = new Health();
        health.Initalize();
    }

    [TearDown]
    public void TearDown()
    {
        health.currentHealth = 0;
    }

    [Test]
    [TestCase(-50)]
    [TestCase(50)]
    public void TryToAddHealth(int heal)
    {
        health.AddHealth(heal);

        Assert.Greater(health.currentHealth, health.startHealth);
    }

    [Test]
    [TestCase(-50)]
    [TestCase(50)]
    public void TryToRemoveHealth(int damage)
    {
        health.RemoveHealth(damage);

        Assert.Less(health.currentHealth, health.startHealth);
    }

    [Test]
    [TestCase(-50)]
    [TestCase(50)]
    public void TryToMakeHealthPoolBigger(int moreHealth)
    {
        health.IncreaseHealthPool(moreHealth);

        Assert.Greater(health.maxHealth, 200);
    }

    [Test]
    [TestCase(-50)]
    [TestCase(50)]
    public void TryToMakeHealthPoolSmaller(int lessHealth)
    {
        health.DecreaseHealthPool(lessHealth);

        Assert.Less(health.maxHealth, 200);
    }

}

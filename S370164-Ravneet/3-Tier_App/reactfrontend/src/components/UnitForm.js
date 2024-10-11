import React, { useState } from 'react';
import { createUnit, updateUnit } from '../api/unitApi';

const UnitForm = ({ existingUnit, onUnitSaved }) => {
  const [unit, setUnit] = useState(existingUnit || { unitCode: '', unitName: '' });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUnit({ ...unit, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (unit.id) {
      await updateUnit(unit.id, unit);
    } else {
      await createUnit(unit);
    }
    onUnitSaved();
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Unit Code</label>
        <input type="text" name="unitCode" value={unit.unitCode} onChange={handleChange} required />
      </div>
      <div>
        <label>Unit Name</label>
        <input type="text" name="unitName" value={unit.unitName} onChange={handleChange} required />
      </div>
      <button type="submit">Save Unit</button>
    </form>
  );
};

export default UnitForm;

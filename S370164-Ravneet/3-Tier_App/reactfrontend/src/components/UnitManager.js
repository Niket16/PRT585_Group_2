import React, { useState } from 'react';
import UnitForm from './UnitForm';
import UnitList from './UnitList';

const UnitManager = () => {
  const [selectedUnit, setSelectedUnit] = useState(null);

  const handleEdit = (unit) => {
    setSelectedUnit(unit);
  };

  const handleUnitSaved = () => {
    setSelectedUnit(null);
  };

  return (
    <div>
      <h1>Unit Manager</h1>
      <UnitForm existingUnit={selectedUnit} onUnitSaved={handleUnitSaved} />
      <UnitList onEdit={handleEdit} />
    </div>
  );
};

export default UnitManager;

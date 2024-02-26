import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select';
import { Textarea } from '@/components/ui/textarea';
import React from 'react';

function House() {
    return (
        <div className="flex justify-center items-center h-full">
            <Card className="w-[400px]">
                <CardHeader>
                    <CardTitle>Update House</CardTitle>
                    <CardDescription></CardDescription>
                </CardHeader>
                <CardContent>
                    <form>
                        <div className="grid w-full items-center gap-4">
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="name">Name : </Label>
                                <Input type='text' id="name"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="houseManagement">House Management : </Label>
                                <Input type='text' id="houseManagement"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="numberOfRooms">Number Of Rooms : </Label>
                                <Input type='number' id="numberOfRooms"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="price">Price : </Label>
                                <Input type='number' id="price"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="description">Description : </Label>
                                <Textarea placeholder="Type your message here." />
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="Status">Status : </Label>
                                {/* <select id="status">
                                    <option value="dangThue">renting</option>
                                    <option value="trong">empty</option>
                                    <option value="khac">others</option>
                                </select> */}
                                <Select>
                                    <SelectTrigger id="framework">
                                        <SelectValue placeholder="Select" />
                                    </SelectTrigger>
                                    <SelectContent position="popper">
                                        <SelectItem value="renting">renting</SelectItem>
                                        <SelectItem value="empty">empty</SelectItem>
                                        <SelectItem value="fixing">fixing</SelectItem>
                                        <SelectItem value="others">others</SelectItem>
                                    </SelectContent>
                                    </Select>
                            </div>
                        </div>
                    </form>
                </CardContent>
                <CardFooter className="flex justify-between">
                    <Button variant="outline">Cancel</Button>
                    <Button>Update</Button>
                </CardFooter>
            </Card>
        </div>
    )
}

export default House;